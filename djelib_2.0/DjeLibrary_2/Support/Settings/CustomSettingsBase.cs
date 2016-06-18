using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;
using DjeLibrary_2.Data;
using log4net;


namespace DjeLibrary_2.Support.Settings
{
    /// <summary>
    /// Base class allowing applicative parameters management, stored in a XML file.
    /// </summary>
    public abstract class CustomSettingsBase
    {
        #region Constantes
        /// <summary>
        /// Noeud racine (ouverture)
        /// </summary>
        private const string _ROOT_NODE_START = "<customSettings>";
        
        /// <summary>
        /// Noeud racine (fermeture)
        /// </summary>
        private const string _ROOT_NODE_END = "</customSettings>";

        /// <summary>
        /// Noeud de paramètre
        /// </summary>
        private const string _PARAM_NODE = "parameter";

        /// <summary>
        /// Nom de l'attribut concernant le nom du paramètre
        /// </summary>
        private const string _NAME_ATTRIBUTE = "name";

        /// <summary>
        /// Nom de l'attribut concernant la valeur du paramètre
        /// </summary>
        private const string _VALUE_ATTRIBUTE = "value";
        #endregion

        #region Properties
        /// <summary>
        /// Chemin du fichier de configuration
        /// </summary>
        public string ConfigFilePath
        {
            get { return _ConfigFilePath; }
            set { _ConfigFilePath = value; }
        }
        private string _ConfigFilePath = @"./settings.xml";

        /// <summary>
        /// Se produit après chargement des paramètres
        /// </summary>
        public SettingsLoadedEventHandler SettingsLoaded
        {
            get { return _SettingsLoaded; }
            set { _SettingsLoaded = value; }
        }
        private SettingsLoadedEventHandler _SettingsLoaded;

        /// <summary>
        /// Se produit avant sauvegarde des paramètres
        /// </summary>
        public SettingsSavingEventHandler SettingsSaving
        {
            get { return _SettingsSaving; }
            set { _SettingsSaving = value; }
        }
        private SettingsSavingEventHandler _SettingsSaving;

        /// <summary>
        /// Se produit après modification d'un paramètre
        /// </summary>
        public SettingChangingEventHandler SettingChanging
        {
            get { return _SettingChanging; }
            set { _SettingChanging = value; }
        }
        private SettingChangingEventHandler _SettingChanging;
        #endregion

        #region Attributs
        /// <summary>
        /// Logger.
        /// </summary>
        private static readonly ILog _log = LogManager.GetLogger(typeof(CustomSettingsBase));

        /// <summary>
        /// Table association nom paramètre - valeur. Valeurs définitives stockées
        /// </summary>
        private readonly Dictionary<string, ICloneable> persistentParameters = new Dictionary<string,ICloneable>();

        /// <summary>
        /// Table association nom paramètre - valeur. Valeurs temporaires stockées
        /// </summary>
        private readonly Dictionary<string, ICloneable> pendingParameters = new Dictionary<string,ICloneable>();
        #endregion

        #region Méthodes publiques
        /// <summary>
        /// Charge les paramètres depuis le fichier XML (ConfigFilePath)
        /// </summary>
        public void Load()
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                // Vérification du fichier XML
                if (File.Exists(ConfigFilePath))
                {
                    doc.Load(ConfigFilePath);

                    // Effacement des listes
                    pendingParameters.Clear();
                    persistentParameters.Clear();

                    // Lecture et création des objets dans le dictionnaire persistant
                    foreach (XmlElement anotherElement in doc.DocumentElement.ChildNodes)
                    {
                        string paramName = anotherElement.Attributes[_NAME_ATTRIBUTE].Value;
                        string paramValue = anotherElement.Attributes[_VALUE_ATTRIBUTE].Value;

                        if (paramName != null)
                            persistentParameters.Add(paramName, paramValue);
                    }
                }
                else
                {
                    _SetDefaultValues();
                    Save();
                }

                // Gestion des événements
                if (_SettingsLoaded != null)
                    _SettingsLoaded.Invoke(this, null);
            }
            catch (Exception ex)
            {
                _log.Error("Unable to load XML config file: " + ConfigFilePath, ex);
                throw (ex);
            }
        }

        /// <summary>
        /// Rend permanentes les modifications apportées aux paramètres
        /// </summary>
        public void Save()
        {
            // Gestion des événements
            if (_SettingsSaving != null)
            {
                CancelEventArgs cancelArgs = new CancelEventArgs();
                _SettingsSaving.Invoke(this, cancelArgs);

                if (cancelArgs.Cancel)
                    return;
            }

            // Parcours des objets en cours
            ICloneable parameterValue;

            foreach (string parameterName in pendingParameters.Keys)
            {
                parameterValue = pendingParameters[parameterName];

                // Mise à jour du paramètre persistent correspondant
                persistentParameters[parameterName] = parameterValue;
            }

            // Mise à jour du fichier XML
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement elementToWrite;
                XmlAttribute nameAttribute;
                XmlAttribute valueAttribute;                

                // Trame du fichier de configuration
                _WriteConfigHeader(xmlDoc);

                foreach (string parameterName in persistentParameters.Keys)
                {
                    parameterValue = persistentParameters[parameterName];

                    string valueToWrite = parameterValue.ToString();

                    // Données XML
                    nameAttribute = xmlDoc.CreateAttribute(_NAME_ATTRIBUTE);
                    nameAttribute.Value = parameterName;

                    valueAttribute = xmlDoc.CreateAttribute(_VALUE_ATTRIBUTE);
                    valueAttribute.Value = valueToWrite;

                    elementToWrite = xmlDoc.CreateElement(_PARAM_NODE);
                    elementToWrite.Attributes.Append(nameAttribute);
                    elementToWrite.Attributes.Append(valueAttribute);

                    xmlDoc.DocumentElement.AppendChild(elementToWrite);
                }

                xmlDoc.Save(ConfigFilePath);
            }
            catch (Exception ex)
            {
                _log.Error("Unable to save configuration into: " + ConfigFilePath, ex);
                throw ex;
            }
        }

        /// <summary>
        /// Annule toutes les modifications apportées aux paramètres depuis le dernier appel à Save()
        /// </summary>
        public void Cancel()
        {
            // Retire tous les objets de la liste en cours
            pendingParameters.Clear();
        }

        /// <summary>
        /// Renvoie la valeur par défaut du paramètre spécifié
        /// </summary>
        /// <param name="parameterName">Nom du paramètre concerné</param>
        /// <returns>Sa valeur par défaut</returns>
        public string GetDefaultValue(string parameterName)
        {
            MemberInfo[] membersInfo = GetType().GetMember(parameterName);

            if (membersInfo != null && membersInfo.Length == 1)
            {
                MemberInfo memberInfo = membersInfo[0];
                object[] attr = memberInfo.GetCustomAttributes(false);

                if (attr != null && attr.Length == 1)
                {
                    if (attr[0].GetType() == typeof(DefaultSettingValueAttribute))
                        return ((DefaultSettingValueAttribute) attr[0]).Value;
                }
            }

            return null;
        }
        #endregion

        #region Méthodes privées
        /// <summary>
        /// Définit les valeurs par défaut de tous les paramètres
        /// </summary>
        /// <returns></returns>
        private void _SetDefaultValues()
        {
            MemberInfo[] allParameters = GetType().GetMembers();

            foreach (MemberInfo anotherMember in allParameters)
            {
                if (anotherMember.MemberType == MemberTypes.Property)
                {
                    string defaultValue = GetDefaultValue(anotherMember.Name);

                    if (defaultValue != null)
                        persistentParameters.Add(anotherMember.Name, defaultValue);
                }
            }
        }
        #endregion

        #region Méthodes protégées
        /// <summary>
        /// Renvoie la valeur du paramètre indiqué
        /// </summary>
        /// <param name="parameterName">Nom du paramètre</param>
        /// <returns>La valeur du paramètre, ou null s'il n'existe pas</returns>
        protected object _GetParameter(string parameterName)
        {
            string parameterValue = null;

            if (string.IsNullOrEmpty(parameterName))
                return null;

            try
            {
                // Si le paramètre n'a pas été accédé depuis la dernière sauvegarde...
                if (!pendingParameters.ContainsKey(parameterName))
                {
                    // ...on place une copie dans la liste en cours
                    if (persistentParameters.ContainsKey(parameterName))
                        parameterValue = (string) persistentParameters[parameterName];
                }
                else
                    // Retourne le paramètre en cours
                    parameterValue = (string) pendingParameters[parameterName];

                // Evo: if value is still null, the default value is returned
                if (parameterValue == null)
                    parameterValue = GetDefaultValue(parameterName);

                return parameterValue;
            }
            catch (Exception ex)
            {
                _log.Error("Unable to get parameter: " + parameterName, ex);
                return null;
            }
        }

        /// <summary>
        /// Définit la valeur du paramètre
        /// </summary>
        /// <param name="parameterName">Nom du paramètre</param>
        /// <param name="parameterValue">Valeur à définir</param>
        protected void _SetParameter(string parameterName, object parameterValue)
        {
            if (string.IsNullOrEmpty(parameterName))
                return;

            // Gestion d'événements
            if (_SettingChanging != null)
                _SettingChanging.Invoke(this, new SettingChangingEventArgs(parameterName, null, null, parameterValue, false));

            try
            {
                // Si le paramètre n'a pas été accédé depuis la dernière sauvegarde...
                ICloneable cloneableValue = parameterValue as ICloneable;

                if (!pendingParameters.ContainsKey(parameterName) && cloneableValue != null)
                    // ...on place une copie dans la liste en cours
                    pendingParameters.Add(parameterName, ((ICloneable) cloneableValue.Clone()));
                else
                    pendingParameters[parameterName] = cloneableValue;
            }
            catch (Exception ex)
            {
                _log.Error("Unable to set parameter: " + parameterName, ex);
            }
        }
        #endregion

        #region Méthodes statiques
        /// <summary>
        /// Ecrit l'entête XML du doc de configuration
        /// </summary>
        /// <param name="doc">Document concerné</param>
        private static void _WriteConfigHeader(XmlDocument doc)
        {
            if (doc == null)
                return;

            doc.LoadXml(XmlHelper.XML_1_0_HEADER + _ROOT_NODE_START + _ROOT_NODE_END);
        }
        #endregion
    }
}
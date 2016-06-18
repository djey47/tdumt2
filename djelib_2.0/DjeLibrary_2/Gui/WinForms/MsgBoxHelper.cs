using System;
using System.Windows.Forms;
using DjeLibrary_2.Gui.Common;

namespace DjeLibrary_2.Gui.WinForms
{
    /// <summary>
    /// Provides methods for invoking commonly used message boxes.
    /// </summary>
    public class MsgBoxHelper : MsgBoxHelperBase
    {
        #region Properties
        public static MsgBoxHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MsgBoxHelper();
                }
                return _Instance;
            }
        }
        private static MsgBoxHelper _Instance;
        #endregion

        private MsgBoxHelper() { }

        #region Méthodes publiques
        /// <summary>
        /// Affiche le message de l'exception spécifiée
        /// </summary>
        public void Error(Form owner, Exception ex)
        {
            _RestoreMouseCursor(owner);

            string msg = _GenerateErrorMessage(ex.Message);
            MessageBox.Show(owner, msg, global::System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Affiche le message d'erreur spécifié
        /// </summary>
        public void Error(Form owner, string message)
        {
            Exception ex = new Exception(message);
            Error(owner, ex);
        }

        /// <summary>
        /// Pose une question.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="question"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public DialogResult Question(Form owner, string question, MessageBoxButtons buttons)
        {
            _RestoreMouseCursor(owner);
            return MessageBox.Show(owner, question, global::System.Windows.Forms.Application.ProductName, buttons, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Affiche un message d'information.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="info"></param>
        public void Info(Form owner, string info)
        {
            _RestoreMouseCursor(owner);
            MessageBox.Show(owner, info, global::System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Affiche un message d'avertissement.
        /// </summary>
        /// <param name="owner">fenêtre parente</param>
        /// <param name="warning">message d'avertissement</param>
        public void Warning(Form owner, string warning)
        {
            Warning(owner, warning, MessageBoxButtons.OK);
        }

        /// <summary>
        /// Affiche un message d'avertissement avec les boutons paramétrés.
        /// </summary>
        /// <param name="owner">fenêtre parente</param>
        /// <param name="warning">message d'avertissement</param>
        /// <param name="buttons">boutons à afficher</param>
        public DialogResult Warning(Form owner, string warning, MessageBoxButtons buttons)
        {
            _RestoreMouseCursor(owner);
            return MessageBox.Show(owner, warning, global::System.Windows.Forms.Application.ProductName, buttons, MessageBoxIcon.Warning);
        }
        #endregion

        #region Méthodes privées
        /// <summary>
        /// Rétablit le curseur par défaut sur la fenêtre spécifiée.
        /// </summary>
        /// <param name="owner">fenêtre concernée</param>
        private static void _RestoreMouseCursor(Form owner)
        {
            // Gestion curseur
            if (owner != null)
            {
                owner.Cursor = Cursors.Default;
            }
        }
        #endregion
    }
}
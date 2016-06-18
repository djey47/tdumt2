using System;
using System.Windows.Forms;

namespace DjeLibrary_2.Forms.Dialogs
{
    /// <summary>
    /// Simple dialog box, allowing to enter a single value
    /// </summary>
    public partial class PromptBox : Form
    {
        #region Properties
        /// <summary>
        /// Valeur saisie
        /// </summary>
        public string ReturnValue
        {
            get { return _ReturnValue; }
        }
        private string _ReturnValue;

        /// <summary>
        /// Indique si la valeur initiale a été modifiée
        /// </summary>
        public bool IsValueChanged
        {
            get { return _IsValueChanged; }
        }
        private bool _IsValueChanged;
       
        /// <summary>
        /// Tells or defines if pressing on Enter key must validate form
        /// </summary>
        public bool OKOnEnterKey
        {
            get { return (AcceptButton == okButton); }
            set
            {
                if (value)
                    AcceptButton = okButton;
                else
                    AcceptButton = null;
            }
        }
        #endregion

        #region Attributs
        /// <summary>
        /// Valeur initiale
        /// </summary>
        private readonly string _InitialValue;
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        protected PromptBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        public PromptBox(string customTitle, string customMessage, string customValue)
        {
            InitializeComponent();

            // Contenu
            Text = customTitle;
            customLabel.Text = customMessage;
            promptTextBox.Text = customValue;

            _InitialValue = customValue;
        }
        #region Private methods
        /// <summary>
        /// =ShowModal()
        /// </summary>
        /// <returns></returns>
        public new DialogResult Show()
        {
            return ShowDialog();
        }

        /// <summary>
        /// =ShowModal(IWin32Window)
        /// </summary>
        /// <returns></returns>
        public new DialogResult Show(IWin32Window owner)
        {
            return ShowDialog(owner);
        }
        #endregion
        #region Events
        private void okButton_Click(object sender, EventArgs e)
        {
            // Clic sur le bouton OK
            _ReturnValue = promptTextBox.Text;
            _IsValueChanged = (_ReturnValue != _InitialValue);
            DialogResult = DialogResult.OK;
        }

        private void promptTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // ENTER key = OK
            if (e.KeyCode == Keys.Enter)
            {
                okButton_Click(sender, new EventArgs());
            }
        }
        #endregion
    }
}
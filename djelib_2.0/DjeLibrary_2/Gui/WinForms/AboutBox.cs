using System;
using System.Drawing;
using System.Windows.Forms;

namespace DjeLibrary_2.Gui.WinForms
{
	/// <summary>
	/// AboutBox
	/// All custom fields must be set before invoking Show or ShowDialog methods.
    /// </summary>
    public partial class AboutBox : Form
    {
        #region Constants
        /// <summary>
        /// Default date
        /// </summary>
        private const string _CUSTOM_DATE_DEFAULT = "201x";

        /// <summary>
        /// Default title
        /// </summary>
        private const string _TITLE_DEFAULT = "About...";

        /// <summary>
        /// Default information
        /// </summary>
	    private const string _CUSTOM_INFO_DEFAULT = "";

        /// <summary>
        /// Word for Version
        /// </summary>
	    private const string _WORD_VERSION = "Version";

        /// <summary>
        /// Separator sequence before date and company information
        /// </summary>
	    private const string _SEPARATOR_DATE_COMPANY = " , ";
        #endregion

        #region Properties
	    /// <summary>
	    /// Message personnalisé à faire apparaître en partie inférieure.
	    /// </summary>
	    public string CustomMessage { get; set; }

	    /// <summary>
	    /// Image personnalisée.
	    /// </summary>
	    public Image CustomImage { get; set; }

	    /// <summary>
        /// Date personnalisée.
        /// </summary>
        public string CustomDate {
            get { return _CustomDate; }
            set {_CustomDate = value; }
        }
        private string _CustomDate = _CUSTOM_DATE_DEFAULT;

        /// <summary>
        /// Custom information (3rd label)
        /// </summary>
	    public string CustomInformation
	    {
            get { return _CustomInformation;  }
            set { _CustomInformation = value; }
	    }
	    private string _CustomInformation = _CUSTOM_INFO_DEFAULT;        
        #endregion

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
		public AboutBox() 
        {
			InitializeComponent();
        }

        #region Public methods
        /// <summary>
        /// =ShowDialog()
        /// </summary>
        /// <returns></returns>
        public new DialogResult Show()
        {
            return ShowDialog();
        }

        /// <summary>
        /// =ShowDialog(IWin32Window)
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public new DialogResult Show(IWin32Window owner)
        {
            return ShowDialog(owner);
        }
        #endregion

        #region Events
        /// <summary>
        /// Chargement de la boîte de dialogue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutBox_Load(object sender, EventArgs e) 
        {
            // Title
            Text = _TITLE_DEFAULT;

            // Application
            lblApplication.Text = global::System.Windows.Forms.Application.ProductName;

            // Version
            lblVersion.Text = string.Concat(_WORD_VERSION, " ", global::System.Windows.Forms.Application.ProductVersion);

            // Société
            lblCompany.Text = string.Concat(CustomDate, _SEPARATOR_DATE_COMPANY, global::System.Windows.Forms.Application.CompanyName);

            // Message personnalisé
            if (CustomMessage != null) 
            {
                txtMessage.Visible = true;
                txtMessage.Text = CustomMessage;
            }

            // Image personnalisée
            if (CustomImage != null) 
            {
                imgCustom.Visible = true;
                imgCustom.Image = CustomImage;
            }

            // Custom information
            if (CustomInformation != null)
            {
                lblCustom.Visible = true;
                lblCustom.Text = CustomInformation;
            }
        }
        #endregion
    }
}
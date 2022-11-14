namespace _Honor_.ContactManager.UI
{
    public partial class Form1 : Form
    {
        public Form1 ()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            Close();
        }

        private void onHelpAbout_Click ( object sender, EventArgs e )
        {
            var about = new AboutContactManager();

            about.ShowDialog();
        }
    }
}
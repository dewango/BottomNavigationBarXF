namespace BottomBarXFExampleXaml
{
	public partial class TabPage
	{
		public TabPage ()
		{
			InitializeComponent ();
            this.Appearing += (sender, e) => Label.Text = string.Format(Label.Text, Title);
        }
	}
}
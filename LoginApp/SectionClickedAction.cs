using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp
{
    public class SectionClickedAction:TriggerAction<Grid>
    {
        public object Section { get; set; }
        public object Page { get; set; }
        protected override void Invoke(Grid sender)
        {
            //navigate to SectionPage
            //if(Section is Section s)
            //{
                Shell.Current.GoToAsync("///SectionPage");
            //}
        }
    }
}

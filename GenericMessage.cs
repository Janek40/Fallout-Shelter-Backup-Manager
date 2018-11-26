using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace FalloutBackupApp
{
    /*This class displays a GenericMessage to the user, there is an OK button and nothing else, this does not close the program*/
    class GenericMessage
    {
        string caption, message;
        Window parent;
        public GenericMessage(string inCaption, string inMessage, Window inParent)
        {
            caption = inCaption;
            message = inMessage;
            parent = inParent;
            display();
        }

        public GenericMessage(string inMessage, Window inParent)
        {
            caption = "";
            message = inMessage;
            parent = inParent;
            display();
        }

        private void display()
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);
        }
    }
}

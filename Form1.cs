using MparWinForm07.Mvc.Controller;
using MparWinForm07.Mvc.Model;
using MparWinForm07.Mvc.Service;
using MparWinForm07.Mvc.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MparWinForm07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
 
            ActionView actionView = new ActionView();
            ActionCodeService actionService = new ActionCodeService();
            IList actionList = actionService.getAllActionCodes();
            //actionList.Add(new ActionCode("1","a"));
            //actionList.Add(new ActionCode("2", "b"));
            ActionCodeController controller = new ActionCodeController(actionView, actionList);
            controller.LoadView();
            actionView.ShowDialog(); ;
        }
    }
}

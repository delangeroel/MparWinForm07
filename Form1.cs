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

        private void CountryButton_Click(object sender, EventArgs e)
        {
            CountryView countryView = new CountryView();
            CountryService countryService = new CountryService();
            IList countryList = countryService.getAllCountries();
            CountryController countryController = new CountryController(countryView, countryList);
            countryController.LoadView();
            countryView.ShowDialog();  
        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
            CustomerView customerView = new CustomerView();
            CustomerService customerService = new CustomerService();
            IList customerList = customerService.getAllCustomers();
            CustomerController customerController = new CustomerController(customerView, customerList);
            customerController.LoadView();
            customerView.ShowDialog();
        }

        private void LoanButton_Click(object sender, EventArgs e)
        {
            LoanView loanView = new LoanView();
            LoanService loanService = new LoanService();
            IList loanList = loanService.getAllLoans();
            LoanController loanController = new LoanController(loanView, loanList);
            loanController.LoadView();
            loanView.ShowDialog();
        }
 
        private void button1_Click_1(object sender, EventArgs e)
        {
            BlogView blogView = new BlogView();
            BlogService blogService = new BlogService();
            IList blogList = new ArrayList();//  blogService.getAllBlogs();
            BlogController blogController = new BlogController(blogView, blogList);
            blogController.LoadView();
            blogView.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Blog2View blog2View = new Blog2View();
            BlogService blogService = new BlogService();
            IList blogList = new ArrayList();//  blogService.getAllBlogs();
            Blog2Controller blog2Controller = new Blog2Controller(blog2View, blogList);
            blog2Controller.LoadView();
            blog2View.ShowDialog();
        }
    }
}

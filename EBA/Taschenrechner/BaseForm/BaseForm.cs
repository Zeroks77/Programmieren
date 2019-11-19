﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class BaseForm : Form
    {
        public double returnUserImputValue = 0;
        public EingabeForm eingabeForm = new EingabeForm();
        public delegate void AdviseParentEventHandler(string text);
        public event AdviseParentEventHandler AdviseParent;
        public BaseForm()
        {
            eingabeForm.AdviseParent += new EingabeForm.AdviseParentEventHandler(SetFromForm2);
            eingabeForm.Font = this.Font;
            eingabeForm.ForeColor = this.ForeColor;
            eingabeForm.BackColor = this.BackColor;
            InitializeComponent();
        }
        public void SetResultInParent(string label)
        {
            AdviseParent(label);
        }
        public void SetFromForm2(string result)
        {
            if ((Regex.Match(result, @"[-]{0,1}[\d]+[,]{0,1}[\d]+").Success))
            {
                returnUserImputValue = Convert.ToDouble(result);
            }
            else
            {
                SetResultInParent(result);
            }
        }
        public void ShowMessage(string Message)
        {
            MessageBox.Show(Message, "Zahleneingabe");
            eingabeForm.ShowDialog();
        }
    }
}

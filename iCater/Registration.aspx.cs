using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iCater
{
    public partial class Registration : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindState();
            }
        }

        #region Methods
        protected void BindState()
        {
            Business.ClientsBAL objClientsBAL = new Business.ClientsBAL();
            DataSet ds = objClientsBAL.GetAllState();
            drpState.DataSource = ds.Tables[0];
            drpState.DataTextField = "StateName";
            drpState.DataValueField = "StateId";
            drpState.DataBind();
            drpState.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void BindCity()
        {
            Business.ClientsBAL objClientsBAL = new Business.ClientsBAL();
            Entity.Clients objClients = new Entity.Clients();
            objClients.StateId = Convert.ToInt32(drpState.SelectedValue);
            DataSet ds = objClientsBAL.GetByStateIdCity(objClients);
            drpCity.DataSource = ds.Tables[0];
            drpCity.DataTextField = "CityName";
            drpCity.DataValueField = "CityId";
            drpCity.DataBind();
            drpCity.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        protected void ClearControls()
        {

            txtBusienssname.Value = "";
            txtFirstName.Value = "";
            txtLastName.Value = "";
            txtMobile.Value = "";
            txtPhone.Value = "";
            txtFax.Value = "";
            txtEmail.Value = "";
            txtPassword.Value = "";
            txtWebsite.Value = "";

            drpState.ClearSelection();
            drpCity.ClearSelection();
            txtArea.Value = "";
            txtPincode.Value = "";
            txtAddress1.Value = "";
            txtAddress2.Value = "";
        }
        #endregion

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                ViewState["FileName"] = FileUpload1.FileName;
                //create the path to save the file to
                string fileName = Path.Combine(Server.MapPath("~/Files"), FileUpload1.FileName);
                //save the file to our local path
                FileUpload1.SaveAs(fileName);
            }
            Business.ClientsBAL objClientsBAL = new Business.ClientsBAL();
            Entity.Clients objClients = new Entity.Clients();
            objClients.BusinessName = txtBusienssname.Value;
            objClients.FirstName = txtFirstName.Value;
            objClients.LastName = txtLastName.Value;
            objClients.Mobile = txtMobile.Value;
            objClients.Phone = txtPhone.Value;
            objClients.FaxNo = txtFax.Value;
            objClients.Email = txtEmail.Value;
            objClients.ClientPassword = txtPassword.Value;
            objClients.Website = txtWebsite.Value;
            objClients.Logo = ViewState["FileName"].ToString();
            objClients.StateId = Convert.ToInt32(drpState.SelectedValue);
            objClients.CityId = Convert.ToInt32(drpCity.SelectedValue);
            objClients.Area = txtArea.Value;
            objClients.Pincode = txtPincode.Value;
            objClients.Address1 = txtAddress1.Value;
            objClients.Address2 = txtAddress2.Value;

            int id = objClientsBAL.InsertClients(objClients);
            if (id > 0)
            {
                ClearControls();
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                ViewState["FileName"] = FileUpload1.FileName;
                //create the path to save the file to
                string fileName = Path.Combine(Server.MapPath("~/Files"), FileUpload1.FileName);
                //save the file to our local path
                FileUpload1.SaveAs(fileName);
                txtPassword.Value = txtPassword.Attributes["value"];

            }
        }

        protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }
        #endregion
        
    }
}
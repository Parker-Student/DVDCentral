using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PF.DVDCentral.BL;
using PF.DVDCentral.BL.Models;

namespace PF.DVDCentral.UI
{
    public partial class Formats : System.Web.UI.Page
    {
        List<Format> formats;
        Format format;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                formats = FormatManager.Load();
                Rebind();

                Session["formats"] = formats;

                ddlFormats_SelectedIndexChanged(sender, e);
            }
            else
            {
                formats = (List<Format>)Session["formats"];
            }
        }
        private void Rebind()
        {
            // Clear out the binding to the ddl
            ddlFormats.DataSource = null;

            // Rebind to the ddl
            ddlFormats.DataSource = formats;

            // Designate the field/property that will be displayed
            ddlFormats.DataTextField = "Description";

            // Designate the field/property that is the primary key.
            ddlFormats.DataValueField = "Id";

            // Do the binding
            ddlFormats.DataBind();

            txtDescription.Text = string.Empty;
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                format = new Format();
                format.Description = txtDescription.Text;
                format.Id = formats[ddlFormats.SelectedIndex].Id;

                int results = FormatManager.Insert(format);
                Response.Write("Inserted " + results + " rows...");

                formats.Add(format);

                Rebind();

                if (results > 0)
                {
                    ddlFormats.SelectedValue = format.Id.ToString();
                }
                ddlFormats_SelectedIndexChanged(sender, e);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                format = formats[ddlFormats.SelectedIndex];

                format.Description = txtDescription.Text;
                // format.DegreeTypeId = degreeTypes[ddlDegreeTypes.SelectedIndex].Id;

                int results = FormatManager.Update(format);
                Response.Write("Updated " + results + " rows...");
                Rebind();

                if (results > 0)
                {
                    ddlFormats.SelectedValue = format.Id.ToString();
                }
                ddlFormats_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                format = formats[ddlFormats.SelectedIndex];

                int results = FormatManager.Delete(format.Id);
                Response.Write("Deleted " + results + " rows...");
                formats.Remove(format);
                Rebind();
                ddlFormats_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ddlFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            format = formats[ddlFormats.SelectedIndex];
            txtDescription.Text = format.Description;
            ddlFormats.SelectedValue = format.Id.ToString();
        }
    }
}
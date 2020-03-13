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
    public partial class Directors : System.Web.UI.Page
    {
        List<Director> directors;
        Director director;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                directors = DirectorManager.Load();
                Rebind();

                Session["directors"] = directors;

                ddlDirectors_SelectedIndexChanged(sender, e);
            }
            else
            {
                directors = (List<Director>)Session["directors"];
            }
        }
        private void Rebind()
        {
            // Clear out the binding to the ddl
            ddlDirectors.DataSource = null;

            // Rebind to the ddl
            ddlDirectors.DataSource = directors;

            // Designate the field/property that will be displayed
            ddlDirectors.DataTextField = "FullNameFirst";

            // Designate the field/property that is the primary key.
            ddlDirectors.DataValueField = "Id";

            // Do the binding
            ddlDirectors.DataBind();

            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;

        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                director = new Director();
                director.FirstName = txtFirstName.Text;
                director.LastName = txtLastName.Text;
                director.Id = directors[ddlDirectors.SelectedIndex].Id;

                int results = DirectorManager.Insert(director);
                
                Response.Write("Inserted " + results + " rows...");

                directors.Add(director);

                Rebind();

                if (results > 0)
                {
                    ddlDirectors.SelectedValue = director.Id.ToString();
                }
                ddlDirectors_SelectedIndexChanged(sender, e);

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
                director = directors[ddlDirectors.SelectedIndex];

                director.FirstName = txtFirstName.Text;
                director.LastName = txtLastName.Text;
                // director.DegreeTypeId = degreeTypes[ddlDegreeTypes.SelectedIndex].Id;

                int results = DirectorManager.Update(director);
                Response.Write("Updated " + results + " rows...");
                Rebind();

                if (results > 0)
                {
                    ddlDirectors.SelectedValue = director.Id.ToString();
                }
                ddlDirectors_SelectedIndexChanged(sender, e);
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
                director = directors[ddlDirectors.SelectedIndex];

                int results = DirectorManager.Delete(director.Id);
                Response.Write("Deleted " + results + " rows...");
                directors.Remove(director);
                Rebind();
                ddlDirectors_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ddlDirectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            director = directors[ddlDirectors.SelectedIndex];
            director.FirstName = txtFirstName.Text;
            director.LastName = txtLastName.Text;
            ddlDirectors.SelectedValue = director.Id.ToString();
        }
    }
}
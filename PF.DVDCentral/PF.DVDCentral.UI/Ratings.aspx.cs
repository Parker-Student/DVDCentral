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
    public partial class Ratings : System.Web.UI.Page
    {
        List<Rating> ratings;
        Rating rating;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ratings = RatingManager.Load();
                Rebind();

                Session["ratings"] = ratings;

                ddlRatings_SelectedIndexChanged(sender, e);
            }
            else
            {
                ratings = (List<Rating>)Session["ratings"];
            }
        }
        private void Rebind()
        {
            // Clear out the binding to the ddl
            ddlRatings.DataSource = null;

            // Rebind to the ddl
            ddlRatings.DataSource = ratings;

            // Designate the field/property that will be displayed
            ddlRatings.DataTextField = "Description";

            // Designate the field/property that is the primary key.
            ddlRatings.DataValueField = "Id";

            // Do the binding
            ddlRatings.DataBind();

            txtDescription.Text = string.Empty;
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                rating = new Rating();
                rating.Description = txtDescription.Text;
                rating.Id = ratings[ddlRatings.SelectedIndex].Id;

                int results = RatingManager.Insert(rating);
                Response.Write("Inserted " + results + " rows...");

                ratings.Add(rating);

                Rebind();

                if (results > 0)
                {
                    ddlRatings.SelectedValue = rating.Id.ToString();
                }
                ddlRatings_SelectedIndexChanged(sender, e);

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
                rating = ratings[ddlRatings.SelectedIndex];

                rating.Description = txtDescription.Text;
               // rating.DegreeTypeId = degreeTypes[ddlDegreeTypes.SelectedIndex].Id;

                int results = RatingManager.Update(rating);
                Response.Write("Updated " + results + " rows...");
                Rebind();

                if (results > 0)
                {
                    ddlRatings.SelectedValue = rating.Id.ToString();
                }
                ddlRatings_SelectedIndexChanged(sender, e);
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
                rating = ratings[ddlRatings.SelectedIndex];

                int results = RatingManager.Delete(rating.Id);
                Response.Write("Deleted " + results + " rows...");
                ratings.Remove(rating);
                Rebind();
                ddlRatings_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ddlRatings_SelectedIndexChanged(object sender, EventArgs e)
        {
            rating = ratings[ddlRatings.SelectedIndex];
            txtDescription.Text = rating.Description;
           ddlRatings.SelectedValue = rating.Id.ToString();
        }
    }
}
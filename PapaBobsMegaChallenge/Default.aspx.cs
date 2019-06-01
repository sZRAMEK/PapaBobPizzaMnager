using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBobsMegaChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                List<FormatedSizeData> pizzasizes = new List<FormatedSizeData>();
                foreach (var item in Domain.PizzaSizeMenager.GetPizzaSizes())
                {
                    pizzasizes.Add(new FormatedSizeData(item));
                }
                DropDownList1.DataSource = pizzasizes;
                DropDownList1.DataValueField = "Id";
                DropDownList1.DataTextField = "TextValue";
                DropDownList1.DataBind();


                List<PapaBobsMegaChallenge.DTO.Crust> CrustsList = Domain.PizzaSizeMenager.GetCrustTypes();
                foreach (var item in CrustsList)
                {
                    if (item.Price!= 0)
                        item.CrustType = string.Format("{0} (${1})", item.CrustType, item.Price);
                }
                DropDownList2.DataSource = CrustsList;
                DropDownList2.DataValueField = "Id";
                DropDownList2.DataTextField = "CrustType";
                DropDownList2.DataBind();


                List<PapaBobsMegaChallenge.DTO.Topping> toppings = Domain.PizzaSizeMenager.GetToppings();
                foreach (var item in toppings)
                {
                    if (item.Price != 0)
                        item.Name = string.Format("{0} (${1})", item.Name, item.Price);
                }
                CheckBoxList1.DataSource = toppings;
                CheckBoxList1.DataValueField = "Id";
                CheckBoxList1.DataTextField = "Name";
                CheckBoxList1.DataBind();


                updatePrice();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePrice();
        }

        public void updatePrice()
        {
            List<Guid> selectedToppingsPrizes = new List<Guid>();
            foreach (ListItem topping in CheckBoxList1.Items)
            {
                if (topping.Selected)
                { 
                selectedToppingsPrizes.Add(Guid.Parse(topping.Value));
                }
            }
            Label9.Text =string.Format("${0}", Domain.PizzaSizeMenager.CalculatePrice(Guid.Parse(DropDownList1.SelectedItem.Value),Guid.Parse(DropDownList2.SelectedItem.Value),selectedToppingsPrizes).ToString()); }

        class FormatedSizeData
        {
            public string TextValue { get; set; }
            public Guid Id { get; set; }
            

            public FormatedSizeData(DTO.Size item)
            {
                TextValue = string.Format("{0} ({1} inch - ${2})", item.Description, item.InchSize, item.Price);
                Id = item.Id;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
           


            string address = TextBox2.Text;
            Guid crustId = Guid.Parse(DropDownList2.SelectedValue);
            string name = TextBox1.Text;
            DTO.PaymentMethod payment;
            if (RadioButton1.Checked) payment = payment = DTO.PaymentMethod.Cash;
            else payment = DTO.PaymentMethod.Credit;
            string phone = TextBox4.Text;
            Guid sizeId = Guid.Parse(DropDownList1.SelectedValue);
            List < Guid >  toppings = new List<Guid>();
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                toppings.Add(Guid.Parse(item.Value));
            }

            string toppingsString = "";
            List<DTO.Topping> toppingslist = Domain.PizzaSizeMenager.GetToppings();
            foreach (var item in toppings)
            {
                toppingsString += toppingslist.Find(x => x.Id == item).Name;
            }





            DTO.Order order = new DTO.Order { Address = address , CrustId = crustId, Name = name, paymentMethod = payment, Phone=phone, SizeId= sizeId , ToppingIds = toppingsString, ZipCode = TextBox3.Text};
            try
            {
                Domain.PizzaSizeMenager.RegisterOrder(order);
               
                Response.Redirect("~//Succes.aspx");
                

            }
            catch (Domain.Exceptions.EmptyFieldException ex)
            {
                switch (ex.fieldName)
                    
                {
                    case "Name":
                        
                        Label1.Text = "Please enter " +ex.fieldName+" !";
                        break;
                    case "Address":

                        Label2.Text = "Please enter " + ex.fieldName + " !";
                        break;
                    case "ZipCode":

                        Label3.Text = "Please enter " + ex.fieldName + " !";
                        break;
                    case "Phone":

                        Label4.Text = "Please enter " + ex.fieldName + " !";
                        break;
                    
                }
                
            }
            
            
        }
    }
}
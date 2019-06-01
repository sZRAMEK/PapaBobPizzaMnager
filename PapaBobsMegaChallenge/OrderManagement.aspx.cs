using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace PapaBobsMegaChallenge
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable table = prepareData();
            GridView1.DataSource = table; 
            GridView1.DataBind();
        }

        private void refreshGridViev()
        {
            DataTable table = prepareData();
            GridView1.DataSource = table;
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        //nie wiem jak lepiej ukryc kolumne
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if(e.Row.Cells.Count>1)
            e.Row.Cells[1].Visible = false;
        }

        private static DataTable prepareData()
        {
            DataTable table = new DataTable();

            List<DTO.Topping> availableToppingsList = Domain.PizzaSizeMenager.GetToppings();
            setUpColumns(table, availableToppingsList);

            List<DTO.PizzaInformations> pizzasList = Domain.PizzaSizeMenager.GetUnfinishedPizzas();
            populateDataTable(table, availableToppingsList, pizzasList);

            return table;
        }
        private static void setUpColumns(DataTable table, List<DTO.Topping> toppings)
        {
            table.Columns.Add("Id", typeof(String));
            table.Columns.Add("Size", typeof(String));
            table.Columns.Add("Crust", typeof(String));

            foreach (var item in toppings)
            {
                table.Columns.Add(item.Name, typeof(Boolean));

            }
        }
        private static void populateDataTable(DataTable table, List<DTO.Topping> availableToppingList, List<DTO.PizzaInformations> pizzaList)
        {
            foreach (var pizza in pizzaList)
            {
                List<object> row = new List<object>();
                row.Add(pizza.Id);
                row.Add(pizza.Size);
                row.Add(pizza.Crust);

                foreach (var topping in availableToppingList)
                {
                    if (pizza.Toppings.Contains(topping.Name))
                        row.Add(true);
                    else row.Add(false);
                }

                table.Rows.Add(row.ToArray());
            }
        }

        

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "FinishOrder") return;
            int rowid = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[rowid];
            Guid orderGuid = Guid.Parse(row.Cells[1].Text);

            Domain.PizzaSizeMenager.FinishOrder(orderGuid);

            refreshGridViev();

        }
    }
}
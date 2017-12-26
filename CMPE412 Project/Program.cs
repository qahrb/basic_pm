using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE412_Project
{
    
    static class Program
    {
        public static int number_of_working_hours=8;
        public static  DateTime Starting_time;
        public static string path;
        public static string name;
        public static string type;
        public static string description;
        public static DateTime start;
        public static DateTime finish;
        public static string country;
        public static string currency;

        // the two lines above are written to keep track of dependencies.
        public static DataSet ods = new DataSet();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
           
            DataTable task = new DataTable("task");
            DataColumn task_name = new DataColumn("task_name");
            task_name.DataType =Type.GetType("System.String") ;
            DataColumn task_duration = new DataColumn("task_duration");
            task_duration.DataType = Type.GetType("System.Int32");
            DataColumn task_duration_type = new DataColumn("task_duration_type");
            task_duration_type.DataType = Type.GetType("System.String");
            DataColumn task_starting_time = new DataColumn("task_starting_time");
            task_starting_time.DataType = Type.GetType("System.DateTime");
            DataColumn task_finishing_time = new DataColumn("task_finishing_time");
            task_finishing_time.DataType = Type.GetType("System.DateTime");


            task.Columns.Add(task_name);
            task.Columns.Add(task_duration);
            task.Columns.Add(task_duration_type);
            task.Columns.Add(task_starting_time);
            task.Columns.Add(task_finishing_time);
        
            
            
            DataTable resources = new DataTable("resources");
            DataColumn res_name = new DataColumn("res_name");
            res_name.DataType = Type.GetType("System.String");
            DataColumn res_salary = new DataColumn("res_salary");
            res_salary.DataType = Type.GetType("System.Double");
            DataColumn res_email = new DataColumn("res_email");
            res_email.DataType = Type.GetType("System.String");
            resources.Columns.Add(res_name);
            resources.Columns.Add(res_salary);
            resources.Columns.Add(res_email);


            DataTable Tas_res = new DataTable("Tas_res");
            DataColumn tres_tname = new DataColumn("tres_tname");
            tres_tname.DataType = Type.GetType("System.String");
            DataColumn tres_rname = new DataColumn("tres_rname");
            tres_rname.DataType = Type.GetType("System.String");
            Tas_res.Columns.Add(tres_tname);
            Tas_res.Columns.Add(tres_rname);

            DataTable Tas_dep = new DataTable("Tas_dep");
            DataColumn Tas_dep_t = new DataColumn("Tas_dep_t");
            Tas_dep_t.DataType = Type.GetType("System.String");
            DataColumn Tas_dep_tp = new DataColumn("Tas_dep_tp");
            Tas_dep_t.DataType = Type.GetType("System.String");
            Tas_dep.Columns.Add(Tas_dep_t);
            Tas_dep.Columns.Add(Tas_dep_tp);
            ods.Tables.Add(task);
            ods.Tables.Add(resources);
            ods.Tables.Add(Tas_res);
            ods.Tables.Add(Tas_dep);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu ());
        }
    }
}

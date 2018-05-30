using System;
using System.Collections.Generic;
using System.Data;
using EFCoreDemo;
using System.Timers;
using System.Threading.Tasks;
 

namespace tttt
{
    class Program
    {
       static String frmTbl_last_record ="", toTbl_last_record="";
       static int toTbl_last_rows=0;
        static void Main(string[] args)
        {
            //timer to run method for every 1 minutes
            int prevSyncTime = 0;
            
            while(true){    
                int curSyncTime = DateTime.Now.Minute;
                if(prevSyncTime != curSyncTime){
                    ex();
                    prevSyncTime = curSyncTime;
                }
            }

            //ex();

        }

        public static void ex(){
                //gether data from tbl_from
                DataTable ds = new DataTable();
                using (var context = new From_Context())
                {
                   
                    ds.Columns.Add("Books");
                    ds.Columns.Add("Authors");

                    foreach(var au in context.tb_data){
                       // ds.Rows.Add
                        ds.Rows.Add(au.Books, au.Authors);
                    }
                    frmTbl_last_record = ds.Rows[(ds.Rows.Count-1)][0].ToString();
                    // Console.WriteLine("frm:" + frmTbl_last_record);
                }
                //gather data from tbl_to
                DataTable ds2 = new DataTable();
                using (var context = new To_Context())
                {
                   
                    ds2.Columns.Add("Books");
                    ds2.Columns.Add("Authors");

                    foreach(var au in context.tb_data){
                       // ds.Rows.Add
                        ds2.Rows.Add(au.Books, au.Authors);
                    }
                    toTbl_last_rows = ds2.Rows.Count; 
                    if(ds2.Rows.Count !=0){
                        toTbl_last_record = ds2.Rows[(ds2.Rows.Count-1)][0].ToString();        
                    }           
                    // Console.WriteLine("to:" + toTbl_last_record);
                    //   Console.WriteLine("l row:" + toTbl_last_rows);
                }

                

                if(frmTbl_last_record != toTbl_last_record){
                    using (var context = new To_Context())
                    { 
                        var book = new Book{};
                        int i;
                        for(i=toTbl_last_rows; i<= ds.Rows.Count-1;i++){
                            
                                book = new Book {                 
                                    Books = ds.Rows[i][0].ToString(), Authors=ds.Rows[i][1].ToString()
                                };
                            
                            context.Add(book);
                            context.SaveChanges();
                            toTbl_last_record = ds.Rows[i][0].ToString();
                            Console.WriteLine("Data Changes Made New Record added Succesfully");
                        }
                     
                        
                    }
                }
        }
    }
}

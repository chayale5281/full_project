using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
using Dto;
namespace Bll
{
    public class Seconde
    {
        dbEntities db = new dbEntities();



        int c, row;
        int[] countwor = new int[6];
        int[] countold = new int[6];

        int dayswor = 0;


        public int difficult_of_old_and_experience_of_wor(int difficulty, int experience)
        {
            //הרמה בין הקושי ליכולת העובד תואמת
            if (difficulty == experience || difficulty == 2 && experience == 3 || difficulty == 1 && experience == 3)
                return 80;
            if (difficulty == 3 && experience == 2 || difficulty == 2 && experience == 1)
                return 60;
            //בכל מקרה אחר 
            return 0;
        }
        public int gender(string gendero, string genderw)
        {
            //אם המין שווה
            if (gendero == genderw)
                return 80;
            else
                return 20;
        }
        public int age(int agew, int ageo)
        {
            if (agew < 60 && agew > 18)
                return 100;
            if (ageo == agew && ageo > 75)
                return 20;
            else
                return 40;
        }
        //פונקציה שמקבלת מטריצת ניקוד והופכת את ערכיה לשלילים
        public DynamicMatrix<int> FromPositiveToneNgativeMatrix(DynamicMatrix<int> mat)
        {



            const int v = 0;
            for (int i = v; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Columns; j++)

                {
                    mat[i, j] *= (-1);
                }
            }

            return mat;
        }
        public void TheSecond()
        {

            string[] arraria = new string[6];
            Dictionary<string, DynamicMatrix<int>> Dictionaryaria = new Dictionary<string, DynamicMatrix<int>>();
            DynamicMatrix<int> di = new DynamicMatrix<int>(2, 3);


            di[0, 0] = 1; di[0, 1] = 1; di[0, 2] = 1; di[1, 0] = 1; di[1, 1] = 1; di[1, 2] = 1;
            oldbll o = new oldbll();

            Foreign_worker f = new Foreign_worker();
            Constraintsold co = new Constraintsold();
            Constraintsforeigenworker cf = new Constraintsforeigenworker();
            List<oldbll> list_o = new List<oldbll>();
            List<Foreign_worker> list_fg = new List<Foreign_worker>();
            List<Constraintsold> list_co = db.Constraintsold.ToList();
            List<Constraintsforeigenworker> list_cfg = db.Constraintsforeigenworker.ToList();
            List<Constraintsforeigenworker> list_fghour = db.Constraintsforeigenworker.ToList();
            List<days_of_wor> list_dayswor = db.days_of_wor.ToList();
            List<Constraintsforeigenworker> list_worker = new List<Constraintsforeigenworker>();
            List<Constraintsold> list_old = new List<Constraintsold>();
            List<Placement> lp = new List<Placement>();
            DynamicMatrix<int> list_old_days;
            DynamicMatrix<int> list_wor_days;
            DynamicMatrix<int> temp=new DynamicMatrix<int>();
            DynamicMatrix<int> temp1 ;
            DynamicMatrix<int> placment;
            int count2 = 0;
            int numofwoincity = 0;
            int countday = 0;


            int x = -1, y = 0,y2=0;
            int[] numofoldtowor;
            int[] daysofwor = new int[7];
            int[] daysofold = new int[7];
            int numold = db.old.Count();
            int numwor = db.Foreign_worker.Count();
            int k = -1, j = -1;
            
            List<Placement> lplacment = new List<Placement>();
            for (int i = 0; i < 6; i++)
            {

                arraria[i] = db.city.ToList()[i].namecity;
                string name = arraria[i];







                int idcity1 = db.city.FirstOrDefault(xi => xi.namecity == name).idcity;
                numofwoincity = db.Constraintsforeigenworker.Where(xi => xi.idcity == idcity1).Count();
                int numofoincity = db.Constraintsold.Where(xi => xi.idcity == idcity1).Count();


                Dictionaryaria.Add(arraria[i], new DynamicMatrix<int>(numofwoincity, numofoincity));
            }
            for (int i = 0; i < 6; i++)
            {
                j = -1;
                k = -1;
                c = -1;
                row = -1;

                list_old_days = new DynamicMatrix<int>();
                list_wor_days = new DynamicMatrix<int>();
                x = -1;
                y = 0;
                numofoldtowor = new int[countwor[i]];
                string name = arraria[i];
                int idcity1 = db.city.FirstOrDefault(xi => xi.namecity == name).idcity;
                int numwors = numofwoincity = db.Constraintsforeigenworker.Where(xi => xi.idcity == idcity1).Count();
                int numofoincity = db.Constraintsold.Where(xi => xi.idcity == idcity1).Count();
                int numolds = numofoincity;
                list_worker = db.Constraintsforeigenworker.Where(xi => xi.idcity == idcity1).ToList();
                list_old = db.Constraintsold.Where(xi => xi.idcity == idcity1).ToList();
                for (int wor = 0; wor < numofwoincity; wor++)
                {
                    cf = list_worker[wor];

                    //if (cf.city.idcity == i + 1 && j < countwor[i])
                    //  {
                    x++;
                    j++;
                    k = -1;
                    y2 = 0;
                    //מוסיף שורה לרשימת הימים של העובד
                    list_wor_days.AddRow();



                    // Uncomment the following line to resolve:  
                    // public MyEnumerator GetEnumerator()
                    //אוביקט שלתוכו נכנסים ימי העובד 
                    days_of_wor2 dd = new days_of_wor2();
                    days_of_wor2 dw = db.days_of_wor2.Where(xi => xi.confid == cf.confid).FirstOrDefault();

                    //int countdaywor = db.days_of_wor.Where(xi => xi.confid == cf.confid).Count();
                    //שמה במערך א הימים של כל עובד
                    daysofwor[0] = dw.isSunday == true ? 1 : 0;
                    daysofwor[1] = dw.isManday == true ? 1 : 0;
                    daysofwor[2] = dw.isTuthday == true ? 1 : 0;
                    daysofwor[3] = dw.isWenthday == true ? 1 : 0;
                    daysofwor[4] = dw.isThursday == true ? 1 : 0;
                    daysofwor[5] = dw.isFriday == true ? 1 : 0;
                    daysofwor[6] = dw.isShabbat == true ? 1 : 0;

                    for (int old = 0; old < numofoincity; old++)
                    {



                        co = list_old[old];
                        // if (co.city.idcity == i + 1 && k < countold[i] - 1 && countwor[i] > 0)

                        // {
                        int countdayold = 0;
                        k++;
                        y2 = 0;
                        days_of_old2 dold = db.days_of_old2.Where(xi => xi.conoID == co.conoID).FirstOrDefault();
                        if (dold != null)
                        {
                            daysofold[0] = dold.isSunday == true ? 1 : 0;
                            daysofold[1] = dold.isManday == true ? 1 : 0;
                            daysofold[2] = dold.isTuthday == true ? 1 : 0;
                            daysofold[3] = dold.isWenthday == true ? 1 : 0;
                            daysofold[4] = dold.isThursday == true ? 1 : 0;
                            daysofold[5] = dold.isFriday == true ? 1 : 0;
                            daysofold[6] = dold.isShabbat == true ? 1 : 0;
                        }
                        //--------------day-------------------//
                        //רשמת ימים של העובד הנוכחי

                        //    List<days_of_wor> dw = db.days_of_wor.Where(x => x.confid == cf.confid).ToList();
                        //   int countdaywor = db.days_of_wor.Where(x => x.confid == cf.confid).Count();
                        //רשימת ימים של זקן נוכחי
                        if (j == 0)
                        {
                            list_old_days.AddRow();
                        }
                        for (int day = 0; day < 7; day++)
                        {
                            if (daysofold[day] == 1 && daysofwor[day] == 1)
                            {
                                Dictionaryaria[arraria[i]][j, k] += 100;
                                countdayold++;
                            }
                            if (j == 0)
                            {
                                if (daysofold[day] == 1)
                                    list_old_days.AddColumn(day + 1, k);
                            }
                            if (k == 0)
                            {
                                if (daysofwor[day] == 1)
                                    list_wor_days.AddColumn(day + 1, j);
                            }
                        }




                        //  Dictionhourwor.Add(count,daywor);



                        if (countdayold < 2)
                            continue;

                        //------------gender---------------//
                        if (cf.gender == co.gender)

                            Dictionaryaria[arraria[i]][j, k] += 100;
                        else
                            Dictionaryaria[arraria[i]][j, k] += gender((string)co.gender, (string)cf.gender);
                        //------------age---------------//

                        Dictionaryaria[arraria[i]][j, k] += age((int)cf.age_of_o, (int)co.age);
                        //-------------langry-----------//
                        if (cf.languagefw == co.languageold)
                            Dictionaryaria[arraria[i]][j, k] += 100;
                        if (cf.languagefw != co.languageold && co.Level_of_functioningo == 3 && cf.Level_of_functioningfg == 3)
                            Dictionaryaria[arraria[i]][j, k] += 60;
                        else
                            Dictionaryaria[arraria[i]][j, k] += 0;

                        //--------------Level_of_functioningfg-------//
                        if (cf.Level_of_functioningfg == co.Level_of_functioningo)
                            Dictionaryaria[arraria[i]][j, k] += 150;
                        else
                            Dictionaryaria[arraria[i]][j, k] += difficult_of_old_and_experience_of_wor((int)co.Level_of_functioningo, (int)cf.Level_of_functioningfg);
                        //---------------money_of_hour-------------//
                        if (cf.money_of_hour == co.hanacha_and_money_for_hour)
                            Dictionaryaria[arraria[i]][j, k] += 100;
                        if (cf.money_of_hour <= co.hanacha_and_money_for_hour)
                            Dictionaryaria[arraria[i]][j, k] += 80;
                        else
                            Dictionaryaria[arraria[i]][j, k] += 40;





                        //---------------- houres------------//
                        if (dw != null && dold != null)
                        {

                            if (dw.hourstartw <= dold.hourstarto && dold.hourendo >= dw.hourendw)
                                Dictionaryaria[arraria[i]][j, k] += 80;


                            if ((dw.hourstartw - dold.hourstarto) == 2 && (dw.hourendw - dold.hourendo) == 2)
                                Dictionaryaria[arraria[i]][j, k] += 60;
                            else
                                Dictionaryaria[arraria[i]][j, k] += 20;

                        }








                        //אם אין התאמה בין השעות אין כלל ניקוד


                        count2++;
                        c = k - 1;


                    }

                }

                row = j - 1;






                //}


                // if (cf.city.idcity == i + 1 && co.city.idcity == i + 1) { 
                // days_of_wor dw = db.days_of_wor.Where(x => x.confid == cf.confid).FirstOrDefault();
                // days_of_old dold = db.days_of_old.Where(x => x.conoID == co.conoID).FirstOrDefault();
                //  }
                temp1 = Dictionaryaria[arraria[i]];
                temp.AddRow();
                for (int a = 0; a < numofwoincity; a++)
                {
                    if(a>0)
                       temp.AddRow();
                    for (int b = 0; b < numofoincity; b++)
                    {
                        temp.AddColumn(temp1[a, b], a);
                    }
                    
                }

                
                Dictionaryaria[arraria[i]] = FromPositiveToneNgativeMatrix(Dictionaryaria[arraria[i]]);
                if (Dictionaryaria[arraria[i]].Rows > 0)
                {
                    int[] arrschuing = hungarianAlgorithem.complete_matrix(Dictionaryaria[arraria[i]]);


                    for (int wor = 0; wor < numofwoincity; wor++)
                    {
                        Placement p = new Placement();
                        int idwor = list_worker[wor].confid;

                        int old = arrschuing[wor];
                        int idold = list_old[old].conoID;
                        int years = 2010, months = 07, days = 1;
                        int yeare = 2022, monthe = 08, daye = 31;
                        DateTime ds = new DateTime(years, months, days++);
                        DateTime de = new DateTime(yeare, monthe, daye--);
                        old ol = db.old.Where(xi => xi.conoID == idold).FirstOrDefault();

                        if (ol != null)
                        {
                            idold = ol.idold;
                            string nameold = ol.fnameold + " " + ol.lnameold;
                            p.nameold = ol.fnameold + " " + ol.lnameold;
                        }

                        Foreign_worker wo = db.Foreign_worker.Where(xi => xi.confid == idwor).FirstOrDefault();
                        if (wo != null)
                        {
                            idwor = wo.idwor;
                            string namewor = wo.fnwor + " " + wo.lnwor;
                            p.namewor = wo.fnwor + " " + wo.lnwor;
                        }
                        if (daye == 1)
                            daye += 30;
                        years += 1;
                        yeare += 1;
                        months += 1;
                        monthe += 1;

                        p.idold = idold;
                        p.idwor = idwor;
                        p.Start_Datep = ds;
                        p.end_Datep = de;




                        db.Placement.Add(p);
                        db.SaveChanges();
                        List<Placement> l = db.Placement.ToList();
                    }

                    //   placment = new DynamicMatrix<int>();
                    //      placment.AddRow();
                    //   countplacement++;
                    //   for (int placement = 0; placement < arrschuing.Length; placement++)
                    //   {
                    //     placment.AddColumn(arrschuing[0], countplacement-1);
                    //   }
                    //אם מספר העובדים קטן ממספר הזקנים
                    while (numofwoincity < numofoincity||numofwoincity==0)
                    {

                        dayes d = new dayes();
                        Dictionaryaria[arraria[i]] = d.removedays(ref temp, ref numofwoincity, ref numofoincity, arrschuing, ref list_old_days, ref list_wor_days,  countday);

                        //  temp[daysw, dayso] = 0;
                        // Dictionaryaria[arraria[i]] = temp;


                        countday = 0;

                        Dictionaryaria[arraria[i]] = FromPositiveToneNgativeMatrix(Dictionaryaria[arraria[i]]);
                        arrschuing = hungarianAlgorithem.complete_matrix(Dictionaryaria[arraria[i]]);
                        for (int wor = 0; wor < numofwoincity; wor++)
                        {
                            int idwor = list_worker[wor].confid;
                            int old = arrschuing[wor];
                            int idold = list_old[old].conoID;
                            int years = 2010, months = 07, days = 1;
                            int yeare = 2022, monthe = 08, daye = 31;
                            DateTime ds = new DateTime(years, months, days++);
                            DateTime de = new DateTime(yeare, monthe, daye--);
                            old ol = db.old.Where(xi => xi.conoID == idold).FirstOrDefault();
                            string nameold = "";
                            string namewor = "";
                            if (ol != null)
                            {
                                idold = ol.idold;
                                nameold = ol.fnameold + " " + ol.lnameold;
                            }
                            Foreign_worker wo = db.Foreign_worker.Where(xi => xi.confid == idwor).FirstOrDefault();
                            if (wo != null)
                            {
                                idwor = wo.idwor;
                                namewor = wo.fnwor + " " + wo.lnwor;
                            }
                            if (daye == 1)
                                daye += 30;
                            years += 1;
                            yeare += 1;
                            months += 1;
                            monthe += 1;
                            Placement p = new Placement();
                            p.idold = idold;
                            p.idwor = idwor;
                            p.Start_Datep = ds;
                            p.end_Datep = de;
                            p.nameold = nameold;
                            p.namewor = namewor;
                            lplacment.Add(p);
                        }


                    }
                }
                //מאתחלים באפס


            }
        }
    }
}

               
          


        

        
        
        
        
 



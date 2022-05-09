using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class dayes
    {
        public DynamicMatrix<int> removedays(ref DynamicMatrix<int> temp, ref int row, ref int column, int[] arr, ref DynamicMatrix<int> list_old_days, ref DynamicMatrix<int> list_wor_days, int countday)
        {
            int r = row, c = column,countdas=0;
            List<int> list_wors = new List<int>();
            List<int> list_olds = new List<int>();
            
            for (int daysw = 0; daysw < row; daysw++)
            {
                for (int dayso = 0; dayso < column; dayso++)
                {
                    int[] count_wor = { 1, 1, 1, 1, 1, 1, 1 };
                    int[] count_old = { 1, 1, 1, 1, 1, 1, 1 };
                    int working_days = 7;
                    if (arr[daysw] == dayso)
                    {
                        if (list_old_days.columns(dayso) > list_wor_days.columns(daysw))
                        {
                            foreach (int d in list_old_days[dayso])
                            {
                                if (list_wor_days[daysw] != null) {
                                foreach (int wors in list_wor_days[daysw])
                                {
                                    if (d == wors)
                                    {
                                        if (d > 0)
                                        {
                                            count_wor[d - 1] = 0;
                                            count_old[d - 1] = 0;
                                        }
                                        else
                                        {
                                            count_wor[d] = 0;
                                            count_old[d] = 0;
                                        }

                                    } }


                                }
                            }
                            
                        }

                        else
                        {
                            int day1 = 0;
                            foreach (int wors in list_wor_days[daysw])
                            {
                                day1++; int day2 = 0;

                                foreach (int d in list_old_days[dayso])
                                {
                                    day2++;
                                    if (d == wors)
                                    {
                                        if (d > 0) {
                                            count_wor[d - 1] = 0;
                                            count_old[d - 1] = 0;
                                        }
                                        else
                                        {
                                            count_wor[d ] = 0;
                                            count_old[d ] = 0;
                                        }
                                    }


                                }
                            }
                             
                        }

                        for (int i = 0; i <working_days; i++)
                        {
                            for (int j = 0; j < list_wor_days.columns(daysw); j++)
                            {
                              if (count_wor[i] == 0&& list_wor_days[daysw][j]== i + 1)
                                list_wor_days[daysw][j] = 0;
                            }
                            
                        }

                        for (int i = 0; i < working_days; i++)
                        {
                            for (int j = 0; j < list_old_days.columns(dayso); j++)
                            {
                                if (count_old[i] == 0 && list_old_days[daysw][j] == i + 1) {
                                    list_old_days[daysw][j] = 0;
                                    countdas++;
                                }
                                
                            }

                        }
                        if (countdas >= list_old_days.columns(dayso))
                            removerowwor(dayso, ref temp);
                        list_wors = list_wor_days[daysw];
                        list_olds = list_old_days[dayso];

                        temp[daysw, dayso] = 0;
                        removeoldwithdays(daysw, ref list_old_days, ref list_wors, ref temp);
                        removearrdays(ref c, ref r, ref list_olds, ref list_wors, countday,daysw,ref temp);




                    }
                    
                }
            }
            row = r;column = c;
            return temp;
        }
        public  void removearrdays(ref int numofoincity,ref int numofwoincity, ref List<int> list_old , ref List<int> list_wors,int countday,int dayw,ref DynamicMatrix<int>temp)
        {
            int count_days = 0;
            countday = 0;
            foreach (int d in list_old)
            {
                if (d == 0)
                    countday++;
                count_days++;
            }
            if (countday == count_days)
                numofoincity--;
            countday = 0;
            count_days = 0;
            foreach (int d in list_wors)
            {
                if (d == 0)
                    countday++;
                count_days++;
            }
            if (countday == count_days)
            { 
                numofwoincity--;
            removecolumnold(dayw, ref temp);}

        }
        public void removeoldwithdays(int wor, ref DynamicMatrix<int> list_old, ref List<int> list_wor, ref DynamicMatrix<int> temp)
        {
            int  countdays = 0,dayy;
            for (int day = 0; day < temp.Columns; day++)
            {
                 foreach (int d in list_old[day])
                    {


                    foreach (int wors in list_wor)
                    {

                        if (d == wors&&wors!=0)
                        {
                            countdays++;
                            
                        }


                    }


                    if (countdays < 2) { 
                         dayy = day;
                        temp[wor, day] = 0;}
                }
            }
        }
        public void removecolumnold(int dayw ,ref DynamicMatrix<int> temp)
        {
            for (int i = 0; i < temp.Columns; i++)
            {
                temp[dayw, i] = 0;
            }
        }
        public void removerowwor(int dayold, ref DynamicMatrix<int> temp)
        {
            for (int i = 0; i < temp.Rows; i++)
            {
                temp[i, dayold] = 0;
            }
        }
    }
}
  


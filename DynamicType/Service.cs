using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DynamicType
{
    public class Service
    {
        /// <summary>
        /// validate dynamic object value is Equal
        /// بررسی مساوی بودن مقدار دو موجودیت
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>
        /// Diffrent property name
        /// نام پراپرتی هایی که مقادیر مساوی ندارند
        /// </returns>
        public string[] GetObjectsDiffrence(dynamic obj1, dynamic obj2)
        {
            //get objects type
            //دریافت جمس هر دو موجودیت
            Type[] types = new Type[] { obj1.GetType(), obj2.GetType() };

            //check type is equal
            //بررسی برابر بودن جنس موجودیت ها
            if (types[0].Equals(types[1]))
            {
                //get all properties from object
                //دریافت تمام پراپرتی های موجودیت
                PropertyInfo[] props = types[0].GetProperties();

                //init different list
                //تعریف لبست مقادیر نامساوی
                List<string> dict = new();

                foreach (PropertyInfo prp in props)
                {
                    //get value from objects property
                    //دریافت مقدار پراپرتی 
                    object[] values = new object[] { prp.GetValue(obj1), prp.GetValue(obj2) };

                    //validate value
                    //بررسی مقدار
                    //اگر یکی از مقادیر -بدون مقدار- یا -نامساوی - باشد | به لیست اضافه میشود
                    if (values[0] != null && values[1] != null)
                    {
                        if (!values[0].Equals(values[1]))
                            //add to diffrent list
                            //اضافه کردن به لیست مغایرت
                            dict.Add(prp.Name);
                    }
                    else
                    {
                        //Null  Value
                        //اضافه کردن به لیست مغایرت
                        dict.Add(prp.Name);
                    }

                }

                //return diffrents
                //لیست پراپرتی های نامساوی
                return dict.ToArray();

            }
            return new string[] { "Fail", "Type is not equel!", "Error" };
        }
    }
}

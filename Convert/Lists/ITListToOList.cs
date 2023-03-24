using NPOI.SS.Formula.Functions;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDLibrary.Convert.Lists
{
    
    /// <summary>
    /// Converts Lists from One Type to another type
    /// </summary>
    public class TListToOList
    {
        /// <summary>
        /// Main Function that returns a list of objects.
        /// Outdated
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="temp"></param>
        /// <returns>A list of objects</returns>
        public static List<Object> CONVERT<T, TOut>(List<T> temp)
        {
            List<Object> outList = new List<Object>();
            foreach (T i in temp)
            {
                outList.Add(ConEle<T, TOut>(i));
            }
            return outList;
        }
        public static string TtoStr(T temp)
        {
            return temp.ToString();
        }
        public static int TtoInt(T temp)
        {
            try
            {
                return int.Parse(temp.ToString());
            }
            catch
            {
                return -1;
            }
        }
        public static bool TtoBool(T temp)
        {
            try
            {
                return bool.Parse(temp.ToString());
            }
            catch
            {
                return false;
            }
        }
        public static double TtoDoub(T temp)
        {
            try
            {
                return double.Parse(temp.ToString());
            }
            catch
            {
                return -1;
            }
        }
        public static Object ConEle<T, TOut>(T temp)
        {
            TOut t = default;
            int INT = default;
            double DOUBLE = default;
            float FLOAT = default;
            bool BOOL = default;
            string STR = default;
            char CHARA = default;
            if (Type.Equals(t, DOUBLE))
            {
                try
                {
                    return double.Parse(temp.ToString());
                }
                catch
                {
                    return default;
                }
            }
            else if (Type.Equals(t, INT)) {
                try
                {
                    return int.Parse(temp.ToString());
                }
                catch
                {
                    return default;
                }
            }
            else if (Type.Equals(t, FLOAT))
            {
                try
                {
                    return float.Parse(temp.ToString());
                }
                catch
                {
                    return default;
                }
            }
            else if (Type.Equals(t, STR))
            {
                try
                {
                    return temp.ToString();
                }
                catch
                {
                    return default;
                }
            }
            else if (Type.Equals(t, BOOL))
            {
                try
                {
                    return bool.Parse(temp.ToString());
                }
                catch
                {
                    return default;
                }
            }
            else if (Type.Equals(t, CHARA))
            {
                try
                {
                    return char.Parse(temp.ToString());
                }
                catch
                {
                    return default;
                }
            }
            else
            {
                return default;
            }
        }
    }


    /// <summary>
    /// New Version of Iteratable List Converter (01/24/2023).  
    /// It Contains Everything that you will need to convert lists
    /// </summary>
    public class ListConverter
    {

        #region These are the Initializers 

        /// <summary>
        /// Initializes a blank ListConverter
        /// </summary>
        public ListConverter()
        {
            // Do Nothing
        }

        /// <summary>
        /// Creates a new ListConverter with the List Already Initialized
        /// </summary>
        /// <param name="inList"></param>
        public ListConverter(List<Object> inList)
        {
            ListToConvert = inList;
        }

        /// <summary>
        /// Creates a new ListConverter with the List Already Initialized
        /// </summary>
        /// <param name="inList"></param>
        public ListConverter(List<int> inList)
        {
            SetList(inList);
        }


        /// <summary>
        /// Creates a new ListConverter with the List Already Initialized
        /// </summary>
        /// <param name="inList"></param>
        public ListConverter(List<double> inList)
        {
            SetList(inList);
        }


        /// <summary>
        /// Creates a new ListConverter with the List Already Initialized
        /// </summary>
        /// <param name="inList"></param>
        public ListConverter(List<bool> inList)
        {
            SetList(inList);
        }


        /// <summary>
        /// Creates a new ListConverter with the List Already Initialized
        /// </summary>
        /// <param name="inList"></param>
        public ListConverter(List<string> inList)
        {
            SetList(inList);
        }
        /// <summary>
        /// Creates a new ListConverter with the List Already Initialized
        /// </summary>
        /// <param name="inList"></param>
        public ListConverter(List<char> inList)
        {
            SetList(inList);
        }


        /// <summary>
        /// Creates a new ListConverter with the List Already Initialized
        /// </summary>
        /// <param name="inList"></param>
        public ListConverter(List<byte> inList)
        {
            SetList(inList);
        }


        /// <summary>
        /// Creates a new instance of ListConverter with the output type and the 
        /// inList already converted and initialized
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="outputType"></param>
        public ListConverter(List<Object> inList, string outputType) 
        {
            SetList(inList);
            OutType = outputType;
            ConvertAll(inList);
        }


        /// <summary>
        /// Creates a new instance of ListConverter with the output type and the 
        /// inList already converted and initialized
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="outputType"></param>
        public ListConverter(List<int> inList, string outputType) 
        {
            SetList(inList);
            OutType = outputType;
            ConvertAll(inList);
        }
        
        /// <summary>
        /// Creates a new instance of ListConverter with the output type and the 
        /// inList already converted and initialized
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="outputType"></param>
        public ListConverter(List<double> inList, string outputType) 
        {
            SetList(inList);
            OutType = outputType;
            ConvertAll(inList);
        }

        
        /// <summary>
        /// Creates a new instance of ListConverter with the output type and the 
        /// inList already converted and initialized
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="outputType"></param>
        public ListConverter(List<string> inList, string outputType) 
        {
            SetList(inList);
            OutType= outputType;
            ConvertAll(inList);
        }

        
        /// <summary>
        /// Creates a new instance of ListConverter with the output type and the 
        /// inList already converted and initialized
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="outputType"></param>
        public ListConverter(List<bool> inList, string outputType) 
        {
            SetList(inList);
            OutType = outputType;
            ConvertAll(inList);
        }


        /// <summary>
        /// Creates a new instance of ListConverter with the output type and the 
        /// inList already converted and initialized
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="outputType"></param>
        public ListConverter(List<char> inList, string outputType)
        {
            SetList(inList);
            OutType = outputType;
            ConvertAll(inList);
        }


        /// <summary>
        /// Creates a new instance of ListConverter with the output type and the 
        /// inList already converted and initialized
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="outputType"></param>
        public ListConverter(List<byte> inList, string outputType)
        {
            SetList(inList);
            OutType = outputType;
            ConvertAll(inList);
        }


        #endregion



        #region These are the Class Variables (Publicly Available)


        #region Output Lists
        // Output Lists

        /// <summary>
        /// Output List when Converting to Ints
        /// </summary>
        public List<Int32> IntList { get; set; }

        /// <summary>
        /// Output List when converting to Doubles
        /// </summary>
        public List<Double> DoubleList { get; set; }

        /// <summary>
        /// Output List when Converting to Strings
        /// </summary>
        public List<String> StringList { get; set; }

        /// <summary>
        /// Output List when Converting to Booleans
        /// </summary>
        public List<Boolean> BooleanList { get; set; }

        /// <summary>
        /// Output List when Converting to Unspecified Objects 
        /// (To Use, set 'OutType' to void or "" and call 'ConvertAll<>()' )
        /// </summary>
        public List<Object> ObjectList { get; set; }

        /// <summary>
        /// Output List when converting to Characters 
        /// </summary>
        public List<Char> CharList { get; set; }

        /// <summary>
        /// Output List when converting to Bytes 
        /// </summary>
        public List<Byte> ByteList { get; set; }

        #endregion


        #region Class Variables
        // Other variables 

        /// <summary>
        /// Used to set Error Messages on or off
        /// </summary>
        public bool Dev { get; set; } = false;
        
        
        /// <summary>
        /// Storage of List To Convert 
        /// </summary>
        public List<Object> ListToConvert { get; set; }


        /// <summary>
        /// Storage for the Output Type
        /// </summary>
        public string OutType { get; set; }

        #endregion


        #endregion



        #region Non-Static Internal Methods

        /// <summary>
        /// Sets the Stored List to the Input stored list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"></param>
        public void SetList<T>(List<T> inList) 
        {
            ListToConvert = new List<Object>();
            foreach (T item in inList) 
            {
                ListToConvert.Add(item);
            }
        }

        /// <summary>
        /// Used Typically in the Initialization, but can be called as long as 
        /// the OutType variable (located in this class) is set.
        /// DOES NOT SET THE TEMPORARY LIST 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList">Must be Entered</param>
        public void ConvertAll<T>(List<T> inList) 
        {
            OutType = OutType.ToLower();
            if ((OutType == "double") || (OutType == "int64") || OutType.Contains("double"))
            {
                // Convert to Int
                DoubleList = ToDouble(inList);
            }
            else if ((OutType == "int") || (OutType == "int32") || OutType.Contains("int"))
            {
                // Convert to Int
                IntList = ToInt(inList);
            }
            else if ((OutType == "bool") || (OutType == "boolean"))
            {
                // Convert to Boolean
                BooleanList = ToBool(inList);
            }
            else if ((OutType == "string") || OutType.Contains("string"))
            {
                // Convert to String
                StringList = ToStrings(inList);
            }
            else 
            {
                // Converts to object
                SetList(inList);

            }
        }

        /// <summary>
        /// Converts a list of "T" type variables to a List of Objects (Non-Static)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public List<Object> ConvertList(string outputType = "string", bool dev = false)
        {
            List<Object> list = new List<Object>();
            List<Object> inList = ListToConvert;
            OutType = outputType;
            outputType = outputType.ToLower();
            int errCount = 0;
            // Convert Each Element
            if (outputType == "string")
            {
                // Convert Each Element to string 
                foreach (T ele in inList)
                {
                    try
                    {
                        list.Add(ele.ToString());
                    }
                    catch (FormatException)
                    {
                        errCount++;
                    }
                }
            }
            else if ((outputType == "double") || (outputType == "int64"))
            {
                // Convert Each Element to double
                foreach (T ele in inList)
                {
                    try
                    {
                        list.Add(System.Convert.ToInt64(ele));
                    }
                    catch (FormatException)
                    {
                        errCount++;
                    }
                }
            }
            else if ((outputType == "int") || (outputType == "int32"))
            {
                // Convert Each Element 
                foreach (T ele in inList)
                {
                    try
                    {
                        list.Add(System.Convert.ToInt32(ele));
                    }
                    catch (FormatException)
                    {
                        errCount++;
                    }
                }
            }
            else if ((outputType == "bool") || (outputType == "boolean"))
            {
                // Convert Each Element 
                foreach (T ele in inList)
                {
                    try
                    {
                        list.Add(System.Convert.ToBoolean(ele));
                    }
                    catch (FormatException)
                    {
                        errCount++;
                    }
                }
            }
            if ((errCount > 0) && (dev))
            {
                throw new FormatException();
            }
            return list;
        }

        /// <summary>
        /// Converts a list of "T" type variables to a List of Ints (Int32)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public List<int> ToInt<T>()
        {
            List<int> list = new List<int>();
            List<object> inList = ListToConvert;
            int errCount = 0; 
            foreach (T ele in inList) 
            {
                try
                {
                    list.Add(System.Convert.ToInt32(ele));
                }
                catch (FormatException) 
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (Dev))
            {
                throw new FormatException();
            }
            IntList = list;
            return list;
        }


        /// <summary>
        /// Converts a list of "T" type variables to a List of Doubles (Int64)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public List<double> ToDouble<T>()
        {
            List<double> list = new List<double>();
            List<object> inList = ListToConvert;
            int errCount = 0;
            foreach (T ele in inList)
            {
                try
                {
                    list.Add(System.Convert.ToDouble(ele));
                }
                catch (FormatException)
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (Dev))
            {
                throw new FormatException();
            }
            DoubleList = list;
            return list;
        }


        /// <summary>
        /// Converts a list of "T" type variables to a List of Strings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public List<string> ToStrings<T>()
        {
            List<string> list = new List<string>();
            List<object> inList = ListToConvert;
            int errCount = 0;
            foreach (T ele in inList)
            {
                try
                {
                    list.Add(ele.ToString());
                }
                catch (FormatException)
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (Dev))
            {
                throw new FormatException();
            }
            StringList = list;
            return list;
        }


        /// <summary>
        /// Converts a list of "T" type variables to a List of Booleans
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public List<bool> ToBool<T>()
        {
            List<bool> list = new List<bool>();
            List<object> inList = ListToConvert;
            int errCount = 0;
            foreach (T ele in inList)
            {
                try
                {
                    list.Add(System.Convert.ToBoolean(ele));
                }
                catch (FormatException)
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (Dev))
            {
                throw new FormatException();
            }
            BooleanList = list;
            return list;
        }


        /// <summary>
        /// Converts a list of "T" type variables to a List of Characters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public List<char> Char<T>()
        {
            List<char> list = new List<char>();
            List<object> inList = ListToConvert;
            int errCount = 0;
            foreach (T ele in inList)
            {
                try
                {
                    list.Add(System.Convert.ToChar(ele));
                }
                catch (FormatException)
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (Dev))
            {
                throw new FormatException();
            }
            CharList = list;
            return list;
        }


        /// <summary>
        /// Converts a list of "T" type variables to a List of Bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public List<byte> ToByte<T>()
        {
            List<byte> list = new List<byte>();
            List<object> inList = ListToConvert;
            int errCount = 0;
            foreach (T ele in inList)
            {
                try
                {
                    list.Add(System.Convert.ToByte(ele));
                }
                catch (FormatException)
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (Dev))
            {
                throw new FormatException();
            }
            ByteList = list;
            return list;
        }

        #endregion



        #region Static Methods (Do not need to initialize the class first)


        /// <summary>
        /// Converts a list of "T" type variables to a List of Ints (Int32)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public static List<int> ToInt<T>(List<T> inList, bool dev = false)
        {
            List<int> list = new List<int>();
            int errCount = 0;
            foreach (T ele in inList)
            {
                try
                {
                    list.Add(System.Convert.ToInt32(ele));
                }
                catch (FormatException)
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (dev))
            {
                throw new FormatException();
            }
            return list;
        }


        /// <summary>
        /// Converts a list of "T" type variables to a List of Doubles (Int64)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public static List<double> ToDouble<T>(List<T> inList, bool dev = false)
        {
            List<double> list = new List<double>();
            int errCount = 0;
            foreach (T ele in inList)
            {
                try
                {
                    list.Add(System.Convert.ToInt64(ele));
                }
                catch (FormatException)
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (dev))
            {
                throw new FormatException();
            }
            return list;
        }


        /// <summary>
        /// Converts a list of "T" type variables to a List of Strings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public static List<string> ToStrings<T>(List<T> inList, bool dev = false)
        {
            List<string> list = new List<string>();
            int errCount = 0;
            foreach (T ele in inList)
            {
                try
                {
                    list.Add(ele.ToString());
                }
                catch (FormatException)
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (dev))
            {
                throw new FormatException();
            }
            return list;
        }


        /// <summary>
        /// Converts a list of "T" type variables to a List of Booleans
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public static List<bool> ToBool<T>(List<T> inList, bool dev = false)
        {
            List<bool> list = new List<bool>();
            int errCount = 0;
            foreach (T ele in inList)
            {
                try
                {
                    list.Add(System.Convert.ToBoolean(ele));
                }
                catch (FormatException)
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (dev))
            {
                throw new FormatException();
            }
            return list;
        }


        /// <summary>
        /// Converts a list of "T" type variables to a List of Characters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public static List<char> ToChar<T>(List<T> inList, bool dev = false)
        {
            List<char> list = new List<char>();
            int errCount = 0;
            foreach (T ele in inList)
            {
                try
                {
                    list.Add(System.Convert.ToChar(ele));
                }
                catch (FormatException)
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (dev))
            {
                throw new FormatException();
            }
            return list;
        }


        /// <summary>
        /// Converts a list of "T" type variables to a List of Bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public static List<byte> ToByte<T>(List<T> inList, bool dev = false)
        {
            List<byte> list = new List<byte>();
            int errCount = 0;
            foreach (T ele in inList)
            {
                try
                {
                    list.Add(System.Convert.ToByte(ele));
                }
                catch (FormatException)
                {
                    errCount++;
                }
            }
            if ((errCount > 0) && (dev))
            {
                throw new FormatException();
            }
            return list;
        }

        /// <summary>
        /// Converts a list of "T" type variables to a List of Objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inList"> List of Values to input</param>
        /// <param name="outputType">String form of the type to convert to</param>
        /// <param name="dev">Boolean to decide whether or not to throw exception</param>
        /// <returns>List of Objects in form of convert-to type</returns>
        /// <exception cref="FormatException"> Thrown in order to notify that an object was invalid</exception>
        public static List<Object> ConvertList<T>(List<T> inList, string outputType = "string", bool dev = false)
        {
            List<Object> list = new List<Object>();
            outputType = outputType.ToLower();
            int errCount = 0;
            // Convert Each Element
            if (outputType == "string")
            {
                // Convert Each Element to string 
                foreach (T ele in inList)
                {
                    try
                    {
                        list.Add(ele.ToString());
                    }
                    catch (FormatException)
                    {
                        errCount++;
                    }
                }
            }
            else if ((outputType == "double") || (outputType == "int64"))
            {
                // Convert Each Element to double
                foreach (T ele in inList)
                {
                    try
                    {
                        list.Add(System.Convert.ToInt64(ele));
                    }
                    catch (FormatException)
                    {
                        errCount++;
                    }
                }
            }
            else if ((outputType == "int") || (outputType == "int32"))
            {
                // Convert Each Element 
                foreach (T ele in inList)
                {
                    try
                    {
                        list.Add(System.Convert.ToInt32(ele));
                    }
                    catch (FormatException)
                    {
                        errCount++;
                    }
                }
            }
            else if ((outputType == "bool") || (outputType == "boolean"))
            {
                // Convert Each Element 
                foreach (T ele in inList)
                {
                    try
                    {
                        list.Add(System.Convert.ToBoolean(ele));
                    }
                    catch (FormatException)
                    {
                        errCount++;
                    }
                }
            }
            if ((errCount > 0) && (dev))
            {
                throw new FormatException();
            }
            return list;
        }

        
        #endregion

    }
}

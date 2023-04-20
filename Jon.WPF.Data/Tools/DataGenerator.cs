using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jon.WPF.Data.Tools
{
    public class DataGenerator
    {
        public static List<object> GenerateRandomObjects(Type objectType, int count)
        {
            List<object> objects = new List<object>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                object obj = Activator.CreateInstance(objectType);

                foreach (var property in objectType.GetProperties())
                {
                    Type propertyType = property.PropertyType;

                    if (propertyType.IsPrimitive || propertyType == typeof(string))
                    {
                        // handle primitive and string types
                        if (propertyType == typeof(int))
                        {
                            property.SetValue(obj, random.Next());
                        }
                        else if (propertyType == typeof(long))
                        {
                            byte[] buffer = new byte[sizeof(long)];
                            random.NextBytes(buffer);
                            property.SetValue(obj, BitConverter.ToInt64(buffer, 0));
                        }
                        else if (propertyType == typeof(double))
                        {
                            property.SetValue(obj, random.NextDouble());
                        }
                        else if (propertyType == typeof(float))
                        {
                            property.SetValue(obj, (float)random.NextDouble());
                        }
                        else if (propertyType == typeof(decimal))
                        {
                            byte scale = (byte)random.Next(29);
                            bool sign = random.Next(2) == 1;
                            int[] bits = new int[4];
                            random.NextBytes(new byte[16]);
                            property.SetValue(obj, new decimal(bits[0], bits[1], bits[2], sign, scale));
                        }
                        else if (propertyType == typeof(bool))
                        {
                            property.SetValue(obj, random.Next(2) == 1);
                        }
                        else if (propertyType == typeof(byte))
                        {
                            byte[] buffer = new byte[1];
                            random.NextBytes(buffer);
                            property.SetValue(obj, buffer[0]);
                        }
                        else if (propertyType == typeof(char))
                        {
                            char randomChar = (char)random.Next(0, ushort.MaxValue + 1);
                            property.SetValue(obj, randomChar);
                        }
                        else if (propertyType == typeof(short))
                        {
                            byte[] buffer = new byte[sizeof(short)];
                            random.NextBytes(buffer);
                            property.SetValue(obj, BitConverter.ToInt16(buffer, 0));
                        }
                        else if (propertyType == typeof(uint))
                        {
                            byte[] buffer = new byte[sizeof(uint)];
                            random.NextBytes(buffer);
                            property.SetValue(obj, BitConverter.ToUInt32(buffer, 0));
                        }
                        else if (propertyType == typeof(ulong))
                        {
                            byte[] buffer = new byte[sizeof(ulong)];
                            random.NextBytes(buffer);
                            property.SetValue(obj, BitConverter.ToUInt64(buffer, 0));
                        }
                        else if (propertyType == typeof(ushort))
                        {
                            byte[] buffer = new byte[sizeof(ushort)];
                            random.NextBytes(buffer);
                            property.SetValue(obj, BitConverter.ToUInt16(buffer, 0));
                        }
                        else if (propertyType == typeof(string))
                        {
                            byte[] buffer = new byte[10];
                            random.NextBytes(buffer);
                            string randomString = Convert.ToBase64String(buffer);
                            property.SetValue(obj, randomString);
                        }
                    }
                    else
                    {
                        // handle complex object types
                        object subObj = Activator.CreateInstance(propertyType);
                        var subObjProperties = propertyType.GetProperties();

                        foreach (var subObjProperty in subObjProperties)
                        {
                            Type subObjPropertyType = subObjProperty.PropertyType;

                            if (subObjPropertyType.IsPrimitive || subObjPropertyType == typeof(string))
                            {
                                // handle primitive and string types
                                if (subObjPropertyType == typeof(int))
                                {
                                    subObjProperty.SetValue(subObj, random.Next());
                                }
                                else if (subObjPropertyType == typeof(long))
                                {
                                    byte[] buffer = new byte[sizeof(long)];
                                    random.NextBytes(buffer);
                                    subObjProperty.SetValue(subObj, BitConverter.ToInt64(buffer, 0));
                                }
                                else if (subObjPropertyType == typeof(double))
                                {
                                    subObjProperty.SetValue(subObj, random.NextDouble());
                                }
                                else if (subObjPropertyType == typeof(float))
                                {
                                    subObjProperty.SetValue(subObj, (float)random.NextDouble());
                                }
                                else if (subObjPropertyType == typeof(decimal))
                                {
                                    byte scale = (byte)random.Next(29);
                                    bool sign = random.Next(2) == 1;
                                    int[] bits = new int[4];
                                    random.NextBytes(new byte[16]);
                                    subObjProperty.SetValue(subObj, new decimal(bits[0], bits[1], bits[2], sign, scale));
                                }
                                else if (subObjPropertyType == typeof(bool))
                                {
                                    subObjProperty.SetValue(subObj, random.Next(2) == 1);
                                }
                                else if (subObjPropertyType == typeof(byte))
                                {
                                    byte[] buffer = new byte[1];
                                    random.NextBytes(buffer);
                                    subObjProperty.SetValue(subObj, buffer[0]);
                                }
                                else if (subObjPropertyType == typeof(char))
                                {
                                    char randomChar = (char)random.Next(0, ushort.MaxValue + 1);
                                    subObjProperty.SetValue(subObj, randomChar);
                                }
                                else if (subObjPropertyType == typeof(short))
                                {
                                    byte[] buffer = new byte[sizeof(short)];
                                    random.NextBytes(buffer);
                                    subObjProperty.SetValue(subObj, BitConverter.ToInt16(buffer, 0));
                                }
                                else if (subObjPropertyType == typeof(uint))
                                {
                                    byte[] buffer = new byte[sizeof(uint)];
                                    random.NextBytes(buffer);
                                    subObjProperty.SetValue(subObj, BitConverter.ToUInt32(buffer, 0));
                                }
                                else if (subObjPropertyType == typeof(ulong))
                                {
                                    byte[] buffer = new byte[sizeof(ulong)];
                                    random.NextBytes(buffer);
                                    subObjProperty.SetValue(subObj, BitConverter.ToUInt64(buffer, 0));
                                }
                                else if (subObjPropertyType == typeof(ushort))
                                {
                                    byte[] buffer = new byte[sizeof(ushort)];
                                    random.NextBytes(buffer);
                                    subObjProperty.SetValue(subObj, BitConverter.ToUInt16(buffer, 0));
                                }
                                else if (subObjPropertyType == typeof(string))
                                {
                                    byte[] buffer = new byte[10];
                                    random.NextBytes(buffer);
                                    string randomString = Convert.ToBase64String(buffer);
                                    subObjProperty.SetValue(subObj, randomString);
                                }
                            }
                            else
                            {
                                // recursively handle sub-objects
                                object subSubObj = Activator.CreateInstance(subObjPropertyType);
                                var subSubObjProperties = subObjPropertyType.GetProperties();
                                foreach (var subSubObjProperty in subSubObjProperties)
                                {
                                    Type subSubObjPropertyType = subSubObjProperty.PropertyType;

                                    if (subSubObjPropertyType.IsPrimitive || subSubObjPropertyType == typeof(string))
                                    {
                                        // handle primitive and string types
                                        if (subSubObjPropertyType == typeof(int))
                                        {
                                            subSubObjProperty.SetValue(subSubObj, random.Next());
                                        }
                                        else if (subSubObjPropertyType == typeof(long))
                                        {
                                            byte[] buffer = new byte[sizeof(long)];
                                            random.NextBytes(buffer);
                                            subSubObjProperty.SetValue(subSubObj, BitConverter.ToInt64(buffer, 0));
                                        }
                                        else if (subSubObjPropertyType.IsValueType)
                                        {
                                            subSubObjProperty.SetValue(subSubObj, Activator.CreateInstance(subSubObjPropertyType));
                                        }
                                        else
                                        {
                                            subSubObjProperty.SetValue(subSubObj, null);
                                        }
                                    }
                                    subObjProperty.SetValue(subObj, subSubObj);
                                }
                            }

                            property.SetValue(obj, subObj);
                        }
                    }

                    objects.Add(obj);
                }

                return objects;
            }
            return objects;
        }
    }
}

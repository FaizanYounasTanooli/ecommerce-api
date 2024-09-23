using System.Reflection;

namespace ecommerce_api.DTO
{
    public class BaseDto
    {
        public T ToModel<T>() where T : new()
        {
            T obj = new T();

            PropertyInfo[] dtoProperties = this.GetType().GetProperties();
            PropertyInfo[] modelProperties = typeof(T).GetProperties();

            foreach (var dtoProp in dtoProperties)
            {
                PropertyInfo correspondingProp = modelProperties.FirstOrDefault(p => p.Name == dtoProp.Name);
                if (correspondingProp != null && correspondingProp.CanWrite)
                {
                    if (correspondingProp.CanWrite)
                    {
                        correspondingProp.SetValue(obj, dtoProp.GetValue(this));
                    }
                }
            }

            return obj;
        }
    }
}

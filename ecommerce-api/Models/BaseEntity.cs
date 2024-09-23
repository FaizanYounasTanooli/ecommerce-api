using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace ecommerce_api.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModfiedAt { get; set; } = DateTime.Now;
        public string CustomerId { get; set; } = string.Empty; 
        public bool Deleted { get; set; } = false;
        public bool Active { get; set; } = true;
        [ForeignKey("userId")]
        public string userId { get; set; } = null!;
        public virtual User User { get; set; }= null!;

        public T ToDTO<T>() where T : new()
        {
            T obj = new T();

            PropertyInfo[] sourceProperties = this.GetType().GetProperties();
            PropertyInfo[] targetProperties = typeof(T).GetProperties();
            foreach (var targetProp in targetProperties)
            {
                var sourceProp = sourceProperties.FirstOrDefault(p => p.Name == targetProp.Name && p.PropertyType == targetProp.PropertyType);

                if (sourceProp != null && sourceProp.CanRead && targetProp.CanWrite)
                {
                    var value = sourceProp.GetValue(this);
                    targetProp.SetValue(obj, value);
                }
            }
            return obj;
        }
    }
}

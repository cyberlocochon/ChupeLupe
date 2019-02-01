using System;
using Xamarin.Forms;

namespace ChupeLupe.Helpers
{
   public interface IDependencyServices
        {
            T Get<T>() where T : class;
        }

        public class DeIDependencyServicesWrapper : IDependencyServices
        {
            public T Get<T>() where T : class
            {
                return DependencyService.Get<T>();
            }
        }

}

using System;
using System.Collections;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;

namespace Cheke.Designer.Studio.Core
{
    public class DesignerSerializationService : IDesignerSerializationService
    {
        private IServiceProvider _serviceProvider;

        public DesignerSerializationService(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        private ComponentSerializationService GetComponentSerializationService()
        {
            return _serviceProvider.GetService(typeof (ComponentSerializationService)) as ComponentSerializationService;
        }

        private IDesignerHost GetDesignerHost()
        {
            return _serviceProvider.GetService(typeof(IDesignerHost)) as IDesignerHost;
        }

        ICollection IDesignerSerializationService.Deserialize(object serializationData)
        {
            if (!(serializationData is SerializationStore))
                throw new ArgumentException("Deserialize: bad serialization store.");

            ComponentSerializationService serializationSvc = this.GetComponentSerializationService();
            if (serializationSvc == null)
                throw new InvalidOperationException("Deserialize: unable to get a reference to ComponentSerializationService.");
            
            IDesignerHost designerHost = this.GetDesignerHost();
            if (designerHost == null)
                throw new InvalidOperationException("Deserialize: unable to get a reference to IDesignerHost.");

            return serializationSvc.Deserialize((SerializationStore) serializationData, designerHost.Container);
        }


        object IDesignerSerializationService.Serialize(ICollection objects)
        {
            ComponentSerializationService serializationSvc = this.GetComponentSerializationService();
            if (serializationSvc == null)
                throw new InvalidOperationException("Serialize: unable to get a reference to ComponentSerializationService.");
           
            SerializationStore store = serializationSvc.CreateStore();
            if (objects != null)
            {
                foreach (object obj in objects)
                {
                    serializationSvc.Serialize(store, obj);
                }
            }

            store.Close();
            return store;
        }
    }
}
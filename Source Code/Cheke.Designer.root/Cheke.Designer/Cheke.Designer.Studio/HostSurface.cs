using System;
using System.Collections;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
using Cheke.Designer.Studio.Core;

namespace Cheke.Designer.Studio
{
    public class HostSurface : DesignSurface
    {
        private int _width = 0;
        private int _height = 0;
        private ISelectionService _selectionService;

        public HostSurface(int width, int height)
        {
            this._width = width;
            this._height = height;
        }

        public void Initialize()
        {
            this.AddService(typeof(INameCreationService), new NameCreationServiceImpl());
            this.AddService(typeof(ComponentSerializationService), new CodeDomComponentSerializationService(this));
            this.AddService(typeof(IMenuCommandService), new MenuCommandServiceImpl(this));
            
            this.AddService(typeof(UndoEngine), new UndoEngineImpl(this));
            this.AddService(typeof(IDesignerSerializationService), new DesignerSerializationService(this));

            this._selectionService = (ISelectionService) (this.ServiceContainer.GetService(typeof (ISelectionService)));
            this._selectionService.SelectionChanged += selectionService_SelectionChanged;
        }

        public void BeginLoad(Type rootComponentType, Control parent)
        {
            this.BeginLoad(rootComponentType);

            Control control = this.View as Control;
            if (control != null)
            {
                control.Parent = parent;
                control.Dock = DockStyle.Fill;
            }
        }

        public IDesignerHost DesignerHost
        {
            get { return this.GetService(typeof (IDesignerHost)) as IDesignerHost; }
        }

        public Control RootComponent
        {
            get { return this.DesignerHost.RootComponent as Control; }
        }

        public void AddService(Type type, object serviceInstance)
        {
            this.ServiceContainer.AddService(type, serviceInstance);
        }

        public void PerformCommand(CommandID command)
        {
            IMenuCommandService commandService = this.GetService(typeof (IMenuCommandService)) as IMenuCommandService;
            if (commandService == null)
                return;

            commandService.GlobalInvoke(command);
        }

        private void selectionService_SelectionChanged(object sender, EventArgs e)
        {
            if (this._selectionService == null)
                return;

            ICollection selectedComponents = this._selectionService.GetSelectedComponents();
            PropertyGrid propertyGrid = (PropertyGrid) this.GetService(typeof (PropertyGrid));

            object[] comps = new object[selectedComponents.Count];
            int i = 0;
            foreach (Object o in selectedComponents)
            {
                comps[i] = o;
                i++;
            }

            propertyGrid.SelectedObjects = comps;
        }

        protected override void OnLoaded(LoadedEventArgs e)
        {
            base.OnLoaded(e);

            this.RootComponent.Width = this._width;
            this.RootComponent.Height = this._height;
        }
    }
}
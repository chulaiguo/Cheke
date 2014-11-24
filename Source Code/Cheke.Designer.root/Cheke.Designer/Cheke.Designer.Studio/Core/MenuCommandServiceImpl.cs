using System;
using System.ComponentModel.Design;

namespace Cheke.Designer.Studio.Core
{
    public class MenuCommandServiceImpl : MenuCommandService
    {
        public MenuCommandServiceImpl(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            MenuCommand undoCommand = new MenuCommand(ExecuteUndo, StandardCommands.Undo);
            base.AddCommand(undoCommand);

            MenuCommand redoCommand = new MenuCommand(ExecuteRedo, StandardCommands.Redo);
            base.AddCommand(redoCommand);
        }

        private void ExecuteUndo(object sender, EventArgs e)
        {
            UndoEngineImpl undoEngine = GetService(typeof (UndoEngine)) as UndoEngineImpl;
            if (undoEngine != null)
                undoEngine.DoUndo();
        }

        private void ExecuteRedo(object sender, EventArgs e)
        {
            UndoEngineImpl undoEngine = GetService(typeof (UndoEngine)) as UndoEngineImpl;
            if (undoEngine != null)
                undoEngine.DoRedo();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Cheke.Designer.Studio.Core
{
    public class UndoEngineImpl : UndoEngine
    {
        private readonly List<UndoUnit> undoUnitList = new List<UndoUnit>();

        // points to the command that should be executed for Redo
        private int currentPos = 0;

        public UndoEngineImpl(IServiceProvider provider)
            : base(provider)
        {
        }

        public void DoUndo()
        {
            if (currentPos > 0)
            {
                UndoUnit undoUnit = undoUnitList[currentPos - 1];
                undoUnit.Undo();
                currentPos--;
            }
            UpdateUndoRedoMenuCommandsStatus();
        }

        public void DoRedo()
        {
            if (currentPos < undoUnitList.Count)
            {
                UndoUnit undoUnit = undoUnitList[currentPos];
                undoUnit.Undo();
                currentPos++;
            }
            UpdateUndoRedoMenuCommandsStatus();
        }

        private void UpdateUndoRedoMenuCommandsStatus()
        {
            MenuCommandService menuCommandService = GetService(typeof (MenuCommandService)) as MenuCommandService;
            if(menuCommandService == null)
                return;

            MenuCommand undoMenuCommand = menuCommandService.FindCommand(StandardCommands.Undo);
            MenuCommand redoMenuCommand = menuCommandService.FindCommand(StandardCommands.Redo);

            if (undoMenuCommand != null)
                undoMenuCommand.Enabled = currentPos > 0;
            if (redoMenuCommand != null)
                redoMenuCommand.Enabled = currentPos < this.undoUnitList.Count;
        }

        protected override void AddUndoUnit(UndoUnit unit)
        {
            undoUnitList.RemoveRange(currentPos, undoUnitList.Count - currentPos);
            undoUnitList.Add(unit);
            currentPos = undoUnitList.Count;
        }

        protected override void DiscardUndoUnit(UndoUnit unit)
        {
            undoUnitList.Remove(unit);
            base.DiscardUndoUnit(unit);
        }
    }
}
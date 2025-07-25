﻿#region BSD License
/*
 * 
 * Original BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
 *  © Component Factory Pty Ltd, 2006 - 2016, (Version 4.5.0.0) All rights reserved.
 * 
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner (aka Wagnerp), Simon Coghlan (aka Smurf-IV), Giduac & Ahmed Abdelhameed et al. 2017 - 2025. All rights reserved.
 *  
 */
#endregion

namespace Krypton.Toolkit
{
    /// <summary>
    /// Base class from which all decorator views inherit.
    /// </summary>
    public abstract class ViewDecorator : ViewBase
    {
        #region Instance Fields
        private ViewBase? _child;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewBase class.
        /// </summary>
        protected ViewDecorator([DisallowNull] ViewBase child)
        {
            Debug.Assert(child != null);
            _child = child;
            _child!.Parent = this;
        }

        /// <summary>
        /// Release unmanaged and optionally managed resources.
        /// </summary>
        /// <param name="disposing">Called from Dispose method.</param>
        protected override void Dispose(bool disposing)
        {
            // If called from explicit call to Dispose
            if (disposing)
            {
                if (_child != null)
                {
                    _child.Dispose();
                    _child = null;
                }
            }
        }

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier
            $"ViewDecorator:{Id}";

        #endregion

        #region Enabled
        /// <summary>
        /// Gets and sets the enabled state of the element.
        /// </summary>
        public override bool Enabled
        {
            get => _child?.Enabled ?? false;
            set => _child!.Enabled = value;
        }
        #endregion

        #region Visible
        /// <summary>
        /// Gets and sets the enabled state of the element.
        /// </summary>
        public override bool Visible
        {
            get => _child?.Visible ?? false;
            set => _child!.Visible = value;
        }
        #endregion

        #region Size & Location
        /// <summary>
        /// Gets and sets the rectangle bounding the client area.
        /// </summary>
        public override Rectangle ClientRectangle
        {
            get => _child?.ClientRectangle ?? Rectangle.Empty;
            set => _child!.ClientRectangle = value;
        }

        /// <summary>
        /// Gets and sets the location of the view inside the parent view.
        /// </summary>
        public override Point ClientLocation
        {
            get => _child?.ClientLocation ?? Point.Empty;
            set => _child!.ClientLocation = value;
        }

        /// <summary>
        /// Gets and sets the size of the view.
        /// </summary>
        public override Size ClientSize
        {
            get => _child?.ClientSize ?? Size.Empty;
            set => _child!.ClientSize = value;
        }

        /// <summary>
        /// Gets and sets the width of the view.
        /// </summary>
        public override int ClientWidth
        {
            get => _child?.ClientWidth ?? 0;
            set => _child!.ClientWidth = value;
        }

        /// <summary>
        /// Gets and sets the height of the view.
        /// </summary>
        public override int ClientHeight
        {
            get => _child?.ClientHeight ?? 0;
            set => _child!.ClientHeight = value;
        }
        #endregion

        #region Eval
        /// <summary>
        /// Evaluate the need for drawing transparent areas.
        /// </summary>
        /// <param name="context">Evaluation context.</param>
        /// <returns>True if transparent areas exist; otherwise false.</returns>
        public override bool EvalTransparentPaint(ViewContext context) => _child?.EvalTransparentPaint(context) ?? false;

        #endregion

        #region Layout
        /// <summary>
        /// Discover the preferred size of the element.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override Size GetPreferredSize(ViewLayoutContext context) => _child?.GetPreferredSize(context) ?? Size.Empty;

        /// <summary>
        /// Perform a layout of the elements.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override void Layout(ViewLayoutContext context) => _child?.Layout(context);

        #endregion

        #region Paint
        /// <summary>
        /// Perform a render of the elements.
        /// </summary>
        /// <param name="context">Rendering context.</param>
        public override void Render(RenderContext context) => _child?.Render(context);

        #endregion

        #region Collection
        /// <summary>
        /// Append a view to the collection.
        /// </summary>
        /// <param name="item">ViewBase reference.</param>
        public override void Add(ViewBase item) => _child?.Add(item);

        /// <summary>
        /// Remove all views from the collection.
        /// </summary>
        public override void Clear() => _child?.Clear();

        /// <summary>
        /// Determines whether the collection contains the view.
        /// </summary>
        /// <param name="item">ViewBase reference.</param>
        /// <returns>True if view found; otherwise false.</returns>
        public override bool Contains(ViewBase item) => _child?.Contains(item) ?? false;

        /// <summary>
        /// Determines whether any part of the view hierarchy is the specified view.
        /// </summary>
        /// <param name="item">ViewBase reference.</param>
        /// <returns>True if view found; otherwise false.</returns>
        public override bool ContainsRecurse(ViewBase? item) => _child?.ContainsRecurse(item) ?? false;

        /// <summary>
        /// Copies views to specified array starting at particular index.
        /// </summary>
        /// <param name="array">Target array.</param>
        /// <param name="arrayIndex">Starting array index.</param>
        public override void CopyTo(ViewBase[] array, int arrayIndex) => _child?.CopyTo(array, arrayIndex);

        /// <summary>
        /// Removes first occurrence of specified view.
        /// </summary>
        /// <param name="item">ViewBase reference.</param>
        /// <returns>True if removed; otherwise false.</returns>
        public override bool Remove(ViewBase item) => _child?.Remove(item) ?? false;

        /// <summary>
        /// Gets the number of views in collection.
        /// </summary>
        public override int Count => _child?.Count ?? 0;

        /// <summary>
        /// Determines the index of the specified view in the collection.
        /// </summary>
        /// <param name="item">ViewBase reference.</param>
        /// <returns>-1 if not found; otherwise index position.</returns>
        public override int IndexOf(ViewBase item) => _child?.IndexOf(item) ?? -1;

        /// <summary>
        /// Inserts a view to the collection at the specified index.
        /// </summary>
        /// <param name="index">Insert index.</param>
        /// <param name="item">ViewBase reference.</param>
        public override void Insert(int index, ViewBase item) => _child?.Insert(index, item);

        /// <summary>
        /// Removes the view at the specified index.
        /// </summary>
        /// <param name="index">Remove index.</param>
        public override void RemoveAt(int index) => _child?.RemoveAt(index);

        /// <summary>
        /// Gets or sets the view at the specified index.
        /// </summary>
        /// <param name="index">ViewBase index.</param>
        /// <returns>ViewBase at specified index.</returns>
        public override ViewBase this[int index]
        {
            get => _child![index];
            set => _child![index] = value;
        }

        /// <summary>
        /// Shallow enumerate forward over children of the element.
        /// </summary>
        /// <returns>Enumerator instance.</returns>
        public override IEnumerator<ViewBase> GetEnumerator() => _child!.GetEnumerator();

        /// <summary>
        /// Deep enumerate forward over children of the element.
        /// </summary>
        /// <returns>Enumerator instance.</returns>
        public override IEnumerable<ViewBase> Recurse() => _child!.Recurse();

        /// <summary>
        /// Shallow enumerate backwards over children of the element.
        /// </summary>
        /// <returns>Enumerator instance.</returns>
        public override IEnumerable<ViewBase> Reverse() => _child!.Reverse();

        /// <summary>
        /// Deep enumerate backwards over children of the element.
        /// </summary>
        /// <returns>Enumerator instance.</returns>
        public override IEnumerable<ViewBase> ReverseRecurse() => _child!.ReverseRecurse();

        #endregion

        #region Controllers
        /// <summary>
        /// Gets and sets the associated mouse controller.
        /// </summary>
        public override IMouseController? MouseController
        {
            get => _child?.MouseController;
            set => _child!.MouseController = value;
        }

        /// <summary>
        /// Gets and sets the associated key controller.
        /// </summary>
        public override IKeyController? KeyController
        {
            get => _child?.KeyController;
            set => _child!.KeyController = value;
        }

        /// <summary>
        /// Gets and sets the associated source controller.
        /// </summary>
        public override ISourceController? SourceController
        {
            get => _child?.SourceController;
            set => _child!.SourceController = value;
        }
        #endregion

        #region Mouse Events
        /// <summary>
        /// Mouse has entered the view.
        /// </summary>
        public override void MouseEnter() =>
            // Bubble event up to the parent
            Parent?.MouseEnter();

        /// <summary>
        /// Mouse has moved inside the view.
        /// </summary>
        /// <param name="pt">Mouse position relative to control.</param>
        public override void MouseMove(Point pt) =>
            // Bubble event up to the parent
            Parent?.MouseMove(pt);

        /// <summary>
        /// Mouse button has been pressed in the view.
        /// </summary>
        /// <param name="pt">Mouse position relative to control.</param>
        /// <param name="button">Mouse button pressed down.</param>
        /// <returns>True if capturing input; otherwise false.</returns>
        public override bool MouseDown(Point pt, MouseButtons button) =>
            // Bubble event up to the parent
            Parent?.MouseDown(pt, button) ?? false;

        /// <summary>
        /// Mouse button has been released in the view.
        /// </summary>
        /// <param name="pt">Mouse position relative to control.</param>
        /// <param name="button">Mouse button released.</param>
        public override void MouseUp(Point pt, MouseButtons button) =>
            // Bubble event up to the parent
            Parent?.MouseUp(pt, button);

        /// <summary>
        /// Mouse has left the view.
        /// </summary>
        /// <param name="next">Reference to view that is next to have the mouse.</param>
        public override void MouseLeave(ViewBase? next) =>
            // Bubble event up to the parent
            Parent?.MouseLeave(next);

        #endregion

        #region Key Events
        /// <summary>
        /// Key has been pressed down.
        /// </summary>
        /// <param name="e">A KeyEventArgs that contains the event data.</param>
        public override void KeyDown(KeyEventArgs e) =>
            // Bubble event up to the parent
            Parent?.KeyDown(e);

        /// <summary>
        /// Key has been pressed.
        /// </summary>
        /// <param name="e">A KeyPressEventArgs that contains the event data.</param>
        public override void KeyPress(KeyPressEventArgs e) =>
            // Bubble event up to the parent
            Parent?.KeyPress(e);

        /// <summary>
        /// Key has been released.
        /// </summary>
        /// <param name="e">A KeyEventArgs that contains the event data.</param>
        /// <returns>True if capturing input; otherwise false.</returns>
        public override bool KeyUp(KeyEventArgs e) =>
            // Bubble event up to the parent
            Parent?.KeyUp(e) ?? false;

        #endregion

        #region Source Events
        /// <summary>
        /// Source control has got the focus.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        public override void GotFocus(Control c) =>
            // Bubble event up to the parent
            Parent?.GotFocus(c);

        /// <summary>
        /// Source control has lost the focus.
        /// </summary>
        /// <param name="c">Reference to the source control instance.</param>
        public override void LostFocus(Control c) =>
            // Bubble event up to the parent
            Parent?.LostFocus(c);

        #endregion

        #region ElementState
        /// <summary>
        /// Gets and sets the visual state of the element.
        /// </summary>
        public override PaletteState ElementState
        {
            get => _child!.ElementState;
            set => _child!.ElementState = value;
        }

        /// <summary>
        /// Gets the visual state taking into account the owning controls state.
        /// </summary>
        public override PaletteState State
        {
            [DebuggerStepThrough]
            get => _child!.State;
        }
        #endregion

        #region FixedState
        /// <summary>
        /// Set a fixed state to override usual behavior and appearance
        /// </summary>
        public override PaletteState FixedState
        {
            get => _child!.FixedState;
            set => _child!.FixedState = value;
        }

        /// <summary>
        /// Clear down the use of the fixed state
        /// </summary>
        public override void ClearFixedState() => _child?.ClearFixedState();

        /// <summary>
        /// Gets a value indicating if view is using a fixed state.
        /// </summary>
        public override bool IsFixed => _child?.IsFixed ?? false;

        #endregion

        #region EnableDependant
        /// <summary>
        /// Get and set the view the enabled state of this view element is dependant on.
        /// </summary>
        public override ViewBase? DependantEnabledState
        {
            get => _child?.DependantEnabledState;
            set => _child!.DependantEnabledState = value;
        }

        /// <summary>
        /// Gets a value indicating if view enabled state is dependant on another view.
        /// </summary>
        public override bool IsEnableDependant => _child?.IsEnableDependant ?? false;

        #endregion

        #region ViewFromPoint
        /// <summary>
        /// Find the view that contains the specified point.
        /// </summary>
        /// <param name="pt">Point in view coordinates.</param>
        /// <returns>ViewBase if a match is found; otherwise false.</returns>
        public override ViewBase? ViewFromPoint(Point pt) => _child?.ViewFromPoint(pt);

        #endregion
    }
}

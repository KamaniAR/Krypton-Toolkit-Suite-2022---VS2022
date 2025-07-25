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
    /// Extends the base class by managing a collection of child views.
    /// </summary>
    public abstract class ViewComposite : ViewBase
    {
        #region Instance Fields
        private readonly List<ViewBase>? _views;

        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ViewComposite class.
        /// </summary>
        protected ViewComposite() =>
            // Default state
            _views = [];

        /// <summary>
        /// Release unmanaged and optionally managed resources.
        /// </summary>
        /// <param name="disposing">Called from Dispose method.</param>
        protected override void Dispose(bool disposing)
        {
            // Dispose of all child views
            if (disposing)
            {
                while (Count > 0)
                {
                    this[0]?.Dispose();
                    RemoveAt(0);
                }

                _views?.Clear();
            }

            // Must call base class to finish disposing
            base.Dispose(disposing);
        }

        /// <summary>
        /// Obtains the String representation of this instance.
        /// </summary>
        /// <returns>User readable name of the instance.</returns>
        public override string ToString() =>
            // Return the class name and instance identifier with child count
            $"ViewComposite:{Id}";

        #endregion

        #region ReverseRenderOrder
        /// <summary>
        /// Gets and sets the use of reverse order when rendering.
        /// </summary>
        public bool ReverseRenderOrder { get; set; }

        #endregion

        #region Eval
        /// <summary>
        /// Evaluate the need for drawing transparent areas.
        /// </summary>
        /// <param name="context">Evaluation context.</param>
        /// <returns>True if transparent areas exist; otherwise false.</returns>
        public override bool EvalTransparentPaint([DisallowNull] ViewContext context)
        {
            Debug.Assert(context != null);

            // Check each child in turn for transparent areas
            foreach (ViewBase child in this)
            {
                // Only investigate visible children
                if (child.Visible)
                {
                    // Any child that returns 'true' completes the process
                    if (child.EvalTransparentPaint(context!))
                    {
                        return true;
                    }
                }
            }

            // Nothing found
            return false;
        }
        #endregion

        #region Layout
        /// <summary>
        /// Discover the preferred size of the element.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override Size GetPreferredSize([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context != null);

            // As a composite we have no preferred size ourself
            var preferredSize = Size.Empty;

            foreach (ViewBase child in this)
            {
                // Only investigate visible children
                if (child.Visible)
                {
                    // Ask child for it's own preferred size
                    Size childPreferred = child.GetPreferredSize(context!);

                    // As a composite we need to be big enough to encompass the largest child
                    if (childPreferred.Width > preferredSize.Width)
                    {
                        preferredSize.Width = childPreferred.Width;
                    }

                    if (childPreferred.Height > preferredSize.Height)
                    {
                        preferredSize.Height = childPreferred.Height;
                    }
                }
            }

            return preferredSize;
        }

        /// <summary>
        /// Perform a layout of the elements.
        /// </summary>
        /// <param name="context">Layout context.</param>
        public override void Layout([DisallowNull] ViewLayoutContext context)
        {
            Debug.Assert(context != null);

            // Ask each child to layout in turn
            foreach (ViewBase child in this.Where(static child => child.Visible))
            {
                child.Layout(context!);
            }
        }
        #endregion

        #region Paint
        /// <summary>
        /// Perform a render of the elements.
        /// </summary>
        /// <param name="context">Rendering context.</param>
        public override void Render([DisallowNull] RenderContext context)
        {
            Debug.Assert(context != null);

            // Perform rendering before any children
            if (context != null)
            {
                RenderBefore(context);

                var ordering = ReverseRenderOrder ? Reverse() : this;

                // Ask each child to render in turn
                foreach (ViewBase child in ordering
                             .Where(child => child.Visible
                                             && child.ClientRectangle.IntersectsWith(context.ClipRect))
                        )
                {
                    child.Render(context);
                }

                // Perform rendering after that of children
                RenderAfter(context);
            }
        }
        #endregion

        #region Collection

        /// <summary>
        /// Append a view to the collection.
        /// </summary>
        /// <param name="item">ViewBase reference.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public override void Add(ViewBase? item)
        {
            // We do not allow null references in the collection
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), @"Cannot add a null view into a composite view.");
            }

            if (_views != null)
            {
                // Let type safe collection perform operation
                _views.Add(item);

                // Setup back reference
                item.Parent = this;
            }
        }

        /// <summary>
        /// Remove all views from the collection.
        /// </summary>
        public override void Clear()
        {
            if (_views != null)
            {
                // Remove back references
                foreach (ViewBase child in _views)
                {
                    child.Parent = null;
                }

                // Let type safe collection perform operation
                _views.Clear();
            }
        }

        /// <summary>
        /// Determines whether the collection contains the view.
        /// </summary>
        /// <param name="item">ViewBase reference.</param>
        /// <returns>True if view found; otherwise false.</returns>
        public override bool Contains(ViewBase item) =>
            // Let type safe collection perform operation
            _views?.Contains(item) ?? false;

        /// <summary>
        /// Determines whether any part of the view hierarchy is the specified view.
        /// </summary>
        /// <param name="item">ViewBase reference.</param>
        /// <returns>True if view found; otherwise false.</returns>
        public override bool ContainsRecurse(ViewBase? item)
        {
            // Check against ourself
            if (this == item)
            {
                return true;
            }

            // Check against all children
            return this.Any(child => child.ContainsRecurse(item));
        }

        /// <summary>
        /// Copies views to specified array starting at particular index.
        /// </summary>
        /// <param name="array">Target array.</param>
        /// <param name="arrayIndex">Starting array index.</param>
        public override void CopyTo(ViewBase[] array, int arrayIndex) =>
            // Let type safe collection perform operation
            _views?.CopyTo(array, arrayIndex);

        /// <summary>
        /// Removes first occurrence of specified view.
        /// </summary>
        /// <param name="item">ViewBase reference.</param>
        /// <returns>True if removed; otherwise false.</returns>
        public override bool Remove(ViewBase? item)
        {
            // Let type safe collection perform operation
            var ret = _views?.Remove(item!) ?? false;

            // Remove back reference only when remove completed with success
            if (ret && item != null)
            {
                item.Parent = null;
            }

            return ret;
        }

        /// <summary>
        /// Gets the number of views in collection.
        /// </summary>
        public override int Count => _views?.Count ?? 0;

        /// <summary>
        /// Determines the index of the specified view in the collection.
        /// </summary>
        /// <param name="item">ViewBase reference.</param>
        /// <returns>-1 if not found; otherwise index position.</returns>
        public override int IndexOf(ViewBase item) =>
            // Let type safe collection perform operation
            _views?.IndexOf(item) ?? -1;

        /// <summary>
        /// Inserts a view to the collection at the specified index.
        /// </summary>
        /// <param name="index">Insert index.</param>
        /// <param name="item">ViewBase reference.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public override void Insert(int index, ViewBase item)
        {
            // We do not allow null references in the collection
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), @"Cannot insert a null view inside a composite view.");
            }

            if (_views != null)
            {
                // Let type safe collection perform operation
                _views.Insert(index, item);

                // Setup back reference
                item.Parent = this;
            }
        }

        /// <summary>
        /// Removes the view at the specified index.
        /// </summary>
        /// <param name="index">Remove index.</param>
        public override void RemoveAt(int index)
        {
            if (_views != null)
            {
                // Cache reference to removing item
                ViewBase item = _views[index];

                // Let type safe collection perform operation
                _views.RemoveAt(index);

                // Remove back reference
                item.Parent = null;
            }
        }

        /// <summary>
        /// Gets or sets the view at the specified index.
        /// </summary>
        /// <param name="index">ViewBase index.</param>
        /// <returns>ViewBase at specified index.</returns>
        public override ViewBase this[int index]
        {
            get => _views![index];

            set
            {
                // We do not allow null references in the collection
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), @"Cannot set a null view into a composite view.");
                }

                if (_views != null)
                {
                    // Cache reference to removing item
                    ViewBase item = _views[index];

                    // Let type safe collection perform operation
                    _views[index] = value;

                    // Remove back reference of old item
                    item.Parent = null;

                    // Setup back reference to new item
                    value.Parent = this;
                }
            }
        }

        /// <summary>
        /// Shallow enumerate forward over children of the element.
        /// </summary>
        /// <returns>Enumerator instance.</returns>
        public override IEnumerator<ViewBase> GetEnumerator() =>
            // Use the boilerplate enumerator exposed from the IList<T>
            _views?.GetEnumerator() ?? (IEnumerator<ViewBase>)new List<ViewBase>().GetEnumerator();

        /// <summary>
        /// Deep enumerate forward over children of the element.
        /// </summary>
        /// <returns>Enumerator instance.</returns>
        public override IEnumerable<ViewBase> Recurse()
        {
            if (_views != null)
            {
                // Enumerate each child in turn
                foreach (ViewBase view in _views)
                {
                    // Recurse inside the child view
                    foreach (ViewBase child in view.Recurse())
                    {
                        yield return child;
                    }

                    // Traverse the view itself
                    yield return view;
                }
            }
        }

        /// <summary>
        /// Shallow enumerate backwards over children of the element.
        /// </summary>
        /// <returns>Enumerator instance.</returns>
        public override IEnumerable<ViewBase> Reverse()
        {
            if (_views != null)
            {
                // Return the child views in reverse order
                for (var i = _views.Count - 1; i >= 0; i--)
                {
                    yield return _views[i];
                }
            }
        }

        /// <summary>
        /// Deep enumerate backwards over children of the element.
        /// </summary>
        /// <returns>Enumerator instance.</returns>
        public override IEnumerable<ViewBase> ReverseRecurse()
        {
            if (_views != null)
            {
                // Enumerate the child views in reverse order
                for (var i = _views.Count - 1; i >= 0; i--)
                {
                    // Traverse the view first
                    yield return _views[i];

                    // Recurse inside the child view
                    foreach (ViewBase child in _views[i].Recurse())
                    {
                        yield return child;
                    }
                }
            }
        }
        #endregion

        #region FixedState
        /// <summary>
        /// Set a fixed state to override usual behavior and appearance
        /// </summary>
        public override PaletteState FixedState
        {
            get => base.FixedState;

            set
            {
                // Let base class store the new setting
                base.FixedState = value;

                // Propagate to all contained elements
                foreach (ViewBase child in this)
                {
                    child.FixedState = value;
                }
            }
        }

        /// <summary>
        /// Clear down the use of the fixed state
        /// </summary>
        public override void ClearFixedState()
        {
            // Let base class clear setting
            base.ClearFixedState();

            // Propagate to all contained elements
            foreach (ViewBase child in this)
            {
                child.ClearFixedState();
            }
        }
        #endregion

        #region ViewFromPoint
        /// <summary>
        /// Find the view that contains the specified point.
        /// </summary>
        /// <param name="pt">Point in view coordinates.</param>
        /// <returns>ViewBase if a match is found; otherwise false.</returns>
        public override ViewBase? ViewFromPoint(Point pt)
        {
            ViewBase? ret = null;

            // Do we contain the point?
            if (ClientRectangle.Contains(pt))
            {
                // Give children a chance to specify a more accurate match but
                // we search the children in reverse order as the last child in 
                // the collection is the top most in the z-order. The mouse is 
                // therefore testing against the most visible child first.
                foreach (ViewBase child in Reverse()
                    .Where(child => child.Visible)
                    .Where(child => child.ClientRectangle.Contains(pt)))
                {
                    // Find child that wants the point
                    ret = child.ViewFromPoint(pt);
                    break;
                }

                // If none of the children, match then we do
                ret ??= this;
            }

            return ret;
        }
        #endregion
    }
}

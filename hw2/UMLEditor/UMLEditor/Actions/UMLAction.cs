using System.Collections.Generic;
using System.Diagnostics;
using UMLEditor.Views;

namespace UMLEditor.Actions
{
    /// <summary>
    /// This is an <code>abstract class</code> for all triggerable UML actions.
    /// An UML action performs the "to-do" operations to UML system when the
    /// corresponding situation satisfied or event fired.
    /// The UML action is triggered and executed when the specific menu item
    /// on menu bar is clicked, or when special key combination is pressed. 
    /// </summary>
    /// <remarks>
    /// This is an <code>abstract class</code> that cannot be <code>new</code>ed
    /// directly by those who is not in the same inheritance chain.
    /// </remarks>
    public abstract class UMLAction
    {
        /// <summary>
        /// Holds the <see cref="Canvas"/> singleton <code>object</code>.
        /// </summary>
        protected Canvas Canvas;

        /// <summary>
        /// Holds the pressed key codes in sequence.
        /// </summary>
        protected List<int> KeyQueue;

        /// <summary>
        /// Generates an <see cref="UMLAction"/> instance.
        /// </summary>
        /// <remarks>
        /// This constructor is invisible for <code>object</code>s that are
        /// not in the same inheritance chain.
        /// </remarks>
        protected UMLAction()
        {
            KeyQueue = new List<int>();
            Canvas = Canvas.GetInstance();
        }

        /// <summary>
        /// Gets the specific key with the given index in the pressed key queue.
        /// </summary>
        /// <param name="index">The index of key code.</param>
        /// <returns>Returns the index-th key code.</returns>
        public int GetKey(int index)
        {
            Debug.Assert(index >= 0 && index <= KeyQueue.Count);
            return KeyQueue[index];
        }

        /// <summary>
        /// Gets the total count of stored key codes in key queue.
        /// </summary>
        /// <returns>
        /// Returns an <code>int</code> as the total count of key queue.
        /// </returns>
        public int GetSize()
        {
            return KeyQueue.Count;
        }

        /// <summary>
        /// Triggers and performs the to-do action.
        /// Tells <see cref="Canvas"/> to repaint itself.
        /// </summary>
        public virtual void Trigger()
        {
            Canvas.GetInstance().Invalidate();
        }
    }
}

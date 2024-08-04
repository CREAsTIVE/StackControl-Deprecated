namespace StackControlWindowsForms
{
	partial class MainWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			OutputContainer = new TextBox();
			CommandInsert = new TextBox();
			InputContainer = new TextBox();
			StackView = new TextBox();
			ClearStack = new CheckBox();
			ExecuteButton = new Button();
			ToSymbols = new CheckBox();
			SuspendLayout();
			// 
			// OutputContainer
			// 
			OutputContainer.Location = new Point(12, 12);
			OutputContainer.Multiline = true;
			OutputContainer.Name = "OutputContainer";
			OutputContainer.ReadOnly = true;
			OutputContainer.Size = new Size(311, 397);
			OutputContainer.TabIndex = 0;
			// 
			// CommandInsert
			// 
			CommandInsert.Location = new Point(12, 415);
			CommandInsert.Name = "CommandInsert";
			CommandInsert.Size = new Size(497, 23);
			CommandInsert.TabIndex = 2;
			// 
			// InputContainer
			// 
			InputContainer.Location = new Point(329, 12);
			InputContainer.Multiline = true;
			InputContainer.Name = "InputContainer";
			InputContainer.Size = new Size(180, 397);
			InputContainer.TabIndex = 3;
			// 
			// StackView
			// 
			StackView.Location = new Point(515, 12);
			StackView.Multiline = true;
			StackView.Name = "StackView";
			StackView.ReadOnly = true;
			StackView.Size = new Size(180, 397);
			StackView.TabIndex = 4;
			// 
			// ClearStack
			// 
			ClearStack.AutoSize = true;
			ClearStack.Checked = true;
			ClearStack.CheckState = CheckState.Checked;
			ClearStack.Location = new Point(701, 12);
			ClearStack.Name = "ClearStack";
			ClearStack.Size = new Size(83, 19);
			ClearStack.TabIndex = 5;
			ClearStack.Text = "Clear stack";
			ClearStack.UseVisualStyleBackColor = true;
			// 
			// ExecuteButton
			// 
			ExecuteButton.Location = new Point(515, 415);
			ExecuteButton.Name = "ExecuteButton";
			ExecuteButton.Size = new Size(75, 23);
			ExecuteButton.TabIndex = 6;
			ExecuteButton.Text = "Execute";
			ExecuteButton.UseVisualStyleBackColor = true;
			ExecuteButton.Click += ExecuteButton_Click;
			// 
			// ToSymbols
			// 
			ToSymbols.AutoSize = true;
			ToSymbols.Checked = true;
			ToSymbols.CheckState = CheckState.Checked;
			ToSymbols.Location = new Point(701, 37);
			ToSymbols.Name = "ToSymbols";
			ToSymbols.Size = new Size(85, 19);
			ToSymbols.TabIndex = 7;
			ToSymbols.Text = "To symbols";
			ToSymbols.UseVisualStyleBackColor = true;
			// 
			// MainWindow
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(938, 450);
			Controls.Add(ToSymbols);
			Controls.Add(ExecuteButton);
			Controls.Add(ClearStack);
			Controls.Add(StackView);
			Controls.Add(InputContainer);
			Controls.Add(CommandInsert);
			Controls.Add(OutputContainer);
			Name = "MainWindow";
			Text = "Stack control";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox OutputContainer;
		private TextBox CommandInsert;
		private TextBox InputContainer;
		private TextBox StackView;
		private CheckBox ClearStack;
		private Button ExecuteButton;
		private CheckBox ToSymbols;
	}
}

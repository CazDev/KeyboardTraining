   M S B A M L   `   `   `  ����J  FKeyboardTrainer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:KeyboardTrainerKeyboardTrainer  5   	   )clr-namespace:MyApp.ToolsMyApp.Tools  5   	        KeyboardTrainer.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:KeyboardTrainer     5   	   +toolsclr-namespace:MyApp.Tools     5   	     � WindowStartupLocation$  CenterScreen=�5	   	   $	��500��5   	   $	��350��5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ 
MainWindow��5   	   ��5
   	   ��  �� Source# Z�� �� 	Converter     MyApp.Tools.RatioConverter   �� ConverterParameter$	 0.5����5   	   �� # Z��   $
 0.25�� � 	Resources 5       �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� CornerRadius ��Name �� Triggers P� Property P� Value��%A  '��       �� 5   
   " ��6   .�5      ��  � ��	 �#3737376+   �� 5       � ��$	 30q�6'   �� 5       � ��
	 �����6+   �� 5       � ��$	 15(�6)   �� 5       �@J�SnapsToDevicePixels	 . 64   �� 5       �@�Cursor$
	 Hand��6'   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� $ 50��6!   #��z��63   ._�5      � .+�5   "   �� $ MyContentPresenter��63   #��z��6O   $��Center=�6s   $��Center=�6�   $��0,0,0,0q�6�   5      5        5"      P� 5#       �@J�IsMouseOver . . �5$   "   ��  � ��	 �#6a00ff6?   �� 5%   "    � ��
	 �����6?   5&      P� 5(       � �� . . �5)   "   ��  � ��	 �#0050ef6?   �� 5*   "    � ��
	 �����6?   5+      5-      5/      50      52      .��54      � -   5         �Name$
 grid��54      
������� � RowDefinitions 55   
   �� 56      $��* �6   �� 57      $��6* �6   �� 58      $��6* �6   �� 59      $��6* �6   .+�5<   
   � .+�5=      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0��6M   $
��auto��6Z   .+�5>      �� -   5         ��Name$ image_githubLink��5>   /   $��15��6   $��15��6$   $
��5, 3q�6I   �� 5?      -   5        $ image_Update��5?   /   $��15��6   $��15��6$   $
��5, 3q�6E   �� 5@      -   5        $ image_Settings��5@   /   $��15��6   $��15��6$   $
��5, 3q�6G   �� 5A      -   5        $ 
image_Info��5A   /   $��15��6   $��15��6$   $
��5, 3q�6C   5B      5C      �� 5E   
   -   5         ��Name$ btn_learning��5E      $��1��6'   $��Lessons��64   6F   �� 5F   
   -   5        $ btn_training��5F      $��2��6'   $��
My results��64   6I   �� 5G   
   -   5        $ 
btn_manual��5G      $��3��6%   $��Manual��62   6C   �� 5I   
   -	   5        $��cb_language��5I       � Cursor$
 Hand��6&   $��3��64   $��30��6A   $��Bottom=�6M   .@�5J      �� 	Russian6!   �� 5K      	English6!   5L      5M      5N      
   M S B A M L   `   `   `  ����J  FKeyboardTrainer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:KeyboardTrainer.ViewsKeyboardTrainer.Views  5   	   )clr-namespace:MyApp.ToolsMyApp.Tools  5   	   !    KeyboardTrainer.Views.Train   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:KeyboardTrainer.Views     5   	   +toolsclr-namespace:MyApp.Tools     5   	     � WindowStyle$
  None=�5
   	   $	��430��5   	   $	��600��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Training��5   	   ��5   	   ��  �� Source# Z�� �� 	Converter     MyApp.Tools.RatioConverter   �� ConverterParameter$	 0.4����5	   	   �� # Z��   $	 0.4��.��5      � -   5         �Name$
 grid��5      
������� � ColumnDefinitions 5   
   �� 5      $
��120* �6   �� 5      $
��550* �6    � RowDefinitions 5   
   �� 5      $	��30* �6   �� 5      $
��220* �6   �� 5      $	��40* �6   �� 5      $
��125* �6   .+�5   
   �� 	 �� Orientation$	 
Horizontal=�6   .+�5      �� -   5        
 ��Name$
 btn_back��5       � Cursor$
 Hand��6&   
���   �$��0q�6G   $	��←��6[   $��20(�6g   $��Center=�6u   $��Arial)�6�   $
��Left=�6�   �� 5      -   5        $
 btn_maximize��5      $
 Hand��6*   
���   �$��0q�6K   $	��❏��6_   $��17(�6k   $��Center=�6y   $��Arial)�6�   $��Center=�6�   �� 5      -   5        $
 btn_normalize��5      $
 Hand��6+   
���   �$��0q�6L   $	��▣��6`   $��17(�6l   $��Center=�6z   $��Arial)�6�   $��Right=�6�   5       �� 5"   
   -   5         ��Name$ textblockText��5"      $��1��6+   
�������$�� ��6Q   $��30(�6Y    �� TextAlignment$
 Left=�6g   $��Center=�6|   $��36��6�   $��2��6�   �� 5#   
   -   5        $ textInfo��5#      $��	Type text��6&   $ Center=�67   $��Center=�6N   $��25(�6i   $��2��6w   
�������$��2��6�   �� 5$   
   -   5        $ 	lbl_retry��5$      $��Retry��6'   $��Center=�64   $ Center=�6Q   $��Center=�6h   $��25(�6�   $��3��6�   
�������$��2��6�   $
 Hand��6�   �� 5%   
   $��3��6   $	 
Horizontal=�6"   $��2��6;   .+�5&      �� $��2��6   $	 Vertical=�6&   .+�5'      �� -   5        $
 lbl_left��5'      $��Chars left:��6*   �� 5(      -	   5        $
 lbl_mistakes��5(      $��
Mistakes: ��6.   �� 5)      -
   5        $
 lbl_time��5)      $��Time: ��6*   5*      5+      5,      5-      
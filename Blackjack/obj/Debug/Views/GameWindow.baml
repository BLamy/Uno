   M S B A M L   `   `   `  ����D  @Blackjack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Uno.Views	Uno.Views  5   	       Uno.Views.GameWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Uno.Views     5   	     � Title$	  Uno��5   	   $��476.873��6   $��535.59��6&    � WindowState$ 	Maximized=�65    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName��%�  '��       �� 5   
   " ��6   .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle . 66   �� 5       � ��$ 23��6*   �� 5       � ��$ 75��6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��Border��6!   $ 2��6/   $��1q�6@   
������ 
������ ._�5      �� $��2q�6/   $��Center=�5   "   $��Center=�5   "   ��. 5   "   5       5      P� 5      	 �@J�IsKeyboardFocused
 . . �5   "   �� $ Border��6)    � ��
 ���� 5   2   5      P� 5       	 �@��IsDefaulted
 . . �5!   "   �� $ Border��6)    � ��
 ���� 5"   2   5#      P� 5$      	 �@J�IsMouseOver
 . . �5%   "   �� $ Border��6)    � ��
 ���� 5&   1   5'      P� 5(      	 � ��
 . . �5)   "   �� $ Border��6)    � ��
 ���� 5*   1   �� 5+   "   $ Border��6)    � ��
 ���� 5,   2   5-      P� 5.      	 � {�
 .  . �5/   "   �� $ Border��6)    � ��
 ���� 50   1   �� 51   "   $ Border��6)    � ��
 ���� 52   2   �� 53   "    � ��
 ���� 6?   54      56      58      59      5:      ��5;      �� 5<   
    �� ImageSource$0 */Blackjack;component/Assets/background.png��6   .��5>      �  � ColumnDefinitions 5?   
   �� 5@      $��* �6   �� 5A      $	��10* �6   �� 5B      $��* �6    � RowDefinitions 5D   
   �� 5E      $��* �6   �� 5F      $��* �6   �� 5G      $��* �6   .+�5I   
   �� -   5        $��ComputerTurnArrow��5I      $��0��6.   $��0��6>   $��Center=�6K   $��Center=�6f   $y�Hidden=�6�   .+�5J      �� $��/Assets/arrow.png��6   5K      �� 5M   
   -   5        $��ComputerPanel��5M      $��1��6*   $��0��6:   $��Center=�6G   $��Center=�6b   .+�5N      �� $
��Auto=�6   $��Hidden=�6@   .��5O      �� -   5        $��ComputerField��5O       �� Orientation$ 
Horizontal=�62   5Q      5R      5S      �� 5U   
   $��1��6   $��1��6%   $��Center=�62   $��Center=�6O   $ 
Horizontal=�6j   .+�5V      �� -   5        $��PlayPile��5V      $
��Left=�6$   $	��157��6?   $��Center=�6L   $	��113��6g   �� 5X      -   5         ��Name$
 draw��5X      $��Right=�6#   $��Center=�6?   $	��113��6Z   $	��157��6f   $��0q�6�   
������ ��5Y      �� 5Z      $��/Assets/deck.png��6   5\      5]      �� 5^   
   -   5        $��playerTurnArrow��5^      $��0��6,   $��2��6<   $��Center=�6I   $��Center=�6d   .+�5_      �� $��/Assets/arrow.png��6   5`      �� 5a   
   -   5        $��PlayerPanel��5a      $��1��6(   $��2��68   $��Center=�6E   $��Center=�6`   .+�5b      �� $
��Auto=�6   $��Hidden=�6@   .��5c      �� -   5        $��PlayerField��5c      $ 
Horizontal=�60   5e      5f      5g      5h      5i      
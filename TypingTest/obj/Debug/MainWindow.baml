   M S B A M L   `   `   `  ����E  ATypingTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TypingTest
TypingTest  5   	       TypingTest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TypingTest     5   	     � Title$  
TypingTest��5   	   $��701.35��6   $��1403.2��6,    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ CanMinimize=�6`   .��5	      � -   5         � RowDefinitions 5
   
   �� 5      $��0* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ DimGray��6    � Offset$
 0.01Q�6/   � 5      $ Black��6   $	 .80Q�6-   5      .+�5   
   �� -   5        	 ��Name$	 	UserInput��5      $��Center=�6%   $��35��6B   $��167,0,164.8,92q�6N   $�� ��6f   $��Bottom=�6n   $
��1065��6�   $��25(�6�   $��2��6�   $y�Hidden=�6�   {�.  $��Candara Light)�6^  
�������
���   �6�  �� 5   
   -   5        
 ��Name$
 	Countdown��5      $��60��6'   $��Center=�61   $��650,0,651.8,145q�6N   $��Bottom=�6g   $��70��6�   $��95��6�    �� TextAlignment$ Center=�6�   $��50(�6�   $��2��6�   $y�Hidden=�6�   $��Candara Light)�6  
�������6"  �� 5   
   -   5        $
 WordDisplay��5      $��Center=�6)   $��60,30,61.8,0q�6F   $
��Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��450��6�   $
��1275��6�   $
��24.5(�6�   $ Center=�6�   $��2��6�   $y�Visible=�6  $��Candara Light)�6  
�������
������ 6O  �� 5   
   -   5         ��Name$ ResultsBackground��5      $��Center=�6/   $	��515��6L   $��265,44,266.8,113q�6Y   $��2��6s   
������ $��Center=�6�   $	��865��6�   $y�Hidden=�6�   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5       � $ DimGray��6#   $
 0.40Q�63   � 5!      $ White��6#   $ 2Q�61   5"      5$      �� 5%   
   -   5        $
 Results��5%      $��Center=�6%   $��436,113,436.8,267q�6B   $��2��6]   $
��Wrap=�6n   $�� ��6�   $��Center=�6�   $	��292��6�   $	��524��6�   $ Center=�6�   $��30(�6�   $y�Hidden=�6  $��Candara Light)�6  
�������64  �� 5&   
   -   5         ��Name$ 
MenuButton��5&      $
��Menu��6%   $��Center=�64   $��625,453,624.8,145q�6Q   $��2��6l   $��Center=�6}   $	��147��6�   $��74��6�   $��30(�6�   $y�Hidden=�6�   {�.  $��Candara Light)�6"  
�������
���iii�6T  �� 5(   
   -   5        $ StartButton��5(      $��Start��6&   $��Center=�66   $��625,0,624.8,113q�6S   $��2��6l   $��Bottom=�6}   $	��147��6�   $��74��6�   $��30(�6�   
�������$��Candara Light)�6  
���iii�60  �� 5)   
   -	   5        $
 Title��5)      $��Center=�6#   $��167,145,164.8,0q�6@   $��2��6Y   $
��Wrap=�6j   $��How fast can you type?��6~   $	��Top=�6�   $	��150��6�   $
��1065��6�   $ Center=�6�   $��75(�6�   $��Candara Light)�6  
�������6.  �� 5+   
   -
   5         ��Name$ 	Copyright��5+      $��
©️ Wise��6#   $
��Left=�65   $��2��6P   $��Bottom=�6a   $��65��6|   $��Candara Light)�6�   
�������$��20(�6�   $��32��6�   5-      5.      
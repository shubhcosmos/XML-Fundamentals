   M S B A M L   `   `   `  ����G  CXDoc.Samples, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:XDoc.Samples.Sample04XDoc.Samples.Sample04  5      E'clr-namespace:XDoc.Samples.UserControlsXDoc.Samples.UserControls  5      %    XDoc.Samples.Sample04.XDocWrite   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2vm#clr-namespace:XDoc.Samples.Sample04     5      @UserControls'clr-namespace:XDoc.Samples.UserControls     5         screenStyle#��[  5        � 	Resources  5      .   (XDoc.Samples.Sample04.XDocWriteViewModel  	viewModel��%   &	         5      6   5      .��5      ��   screenBorder#��[ 6   ._�5      �  � DataContext 6   ��  �� Source# [  � RowDefinitions 5      �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6   �� 5   
   $��* �6   .+�5      � $��0��6   .+�5   
   �� -   5        $��	XDocument��5      5      �� 5   
   -   5        $��	XmlWriter��5      5      �� 5   
   -   5        $��XmlWriter Formatting��5      5      �� 5   
   -   5        $��DataSet��5      5      5    	   �� 5!      $��1��6    �� Orientation$ 
Horizontal=�5"      .+�5#   
   �� $��XML File Name to Write��6   �� 5$   
   $	��100��5%      ��5$      ��  �� Path$ XmlFileName�5%      �� 5&   
   -   5        $��	Read File��5&      5'      5(   	   �� 5)      $��2��6   $ 
Horizontal=�5*      .+�5+   
   �� $��XSD File Name to Write��6   �� 5,   
   $	��100��5-      ��5,      �� $ XsdFileName�5-      �� 5.   
   -   5        $��	Read File��5.      5/      50   	   -   'XDoc.Samples.UserControls.ResultControl  51      $��3��6#   52      53      54      
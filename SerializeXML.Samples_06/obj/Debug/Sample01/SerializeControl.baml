   M S B A M L   `   `   `  ����O  KSerializeXML.Samples, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:SerializeXML.Samples.Sample01SerializeXML.Samples.Sample01  5      U/clr-namespace:SerializeXML.Samples.UserControls!SerializeXML.Samples.UserControls  5      :    4SerializeXML.Samples.Sample01.SerializeSampleControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :vm+clr-namespace:SerializeXML.Samples.Sample01     5      HUserControls/clr-namespace:SerializeXML.Samples.UserControls     5         screenStyle#��[  5        � 	Resources  5      <   6SerializeXML.Samples.Sample01.SerializeSampleViewModel  	viewModel��%   &	         5      6"   5      .��5      ��   screenBorder#��[ 6   ._�5      �  � DataContext 6   ��  �� Source# [  � RowDefinitions 5      �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6   �� 5   
   $��* �6   .+�5      �� $!��Simple Serialization Sample��6   $��0��5      $��24(�5      � 5      $��1��6   .+�5   
   �� -   5        $��Serialize Customer��5      5      �� 5   
   -   5        $��Deserialize Customer��5      5      5    	   �� 5!      $��2��6    �� Orientation$ 
Horizontal=�5"      .+�5#   
   �� $��	File Name��6   �� 5$   
   ��6   ��  �� Path$ XmlFileName��� 5%   
   -   5        $��	Read File��5%      5&      5'   	   6   0SerializeXML.Samples.UserControls.CustomerDetail  5(      $��3��6$   5   /SerializeXML.Samples.UserControls.ResultControl  5)      $��4��6#   5*      5+      5,      
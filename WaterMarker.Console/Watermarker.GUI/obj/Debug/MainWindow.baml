   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   J FWatermarker.GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Watermarker.GUI.ViewModelsWatermarker.GUI.ViewModels 5   	   7 clr-namespace:Watermarker.ConfigWatermarker.Config 5   	   ?$clr-namespace:Watermarker.ConvertersWatermarker.Converters 5	   	   A%clr-namespace:Watermarker.DataSourcesWatermarker.DataSources 5
   	       Watermarker.GUI.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   7vm(clr-namespace:Watermarker.GUI.ViewModels     5   	   /wm clr-namespace:Watermarker.Config     5   	   3cv$clr-namespace:Watermarker.Converters     5	   	   4ds%clr-namespace:Watermarker.DataSources     5
   	     � Title$  Watermarker��5   	   $	��430��6    � SizeToContent$ Height=�5   	    � 
ResizeMode$ NoResize=�6     � Icon$ Resources/icon.ico��5   	   .��5      � $��6q�6    � 	Resources 5   
   7  1Watermarker.Converters.AnchorDescriptionConverter   anchorDescriptionConverter9  3Watermarker.Converters.FontTypeDescriptionConverter   fontTypeDescriptionConverter@  :Watermarker.Converters.TextOrientationDescriptionConverter ' #textOrientationDescriptionConverter  PositionSource S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName  FontTypeSource  TextOrientationSource  
FontSource,  &Watermarker.DataSources.FontDataSource  InnerMargin	 �� 
TargetType
 �� Property �� Value��%  &	        &	      &	 &     &	 9     &	 �     &	     &	 v    &	 �    '�� �    '�� 
    7  '�� N    7  '�� �    7    5      6,     5      6.     5      65   S� 5      $ 	GetValues��68   "  6O    5      M� 5      $ 	wm:Anchor��6   5      S� 5      $ 	GetValues��68   "  6O    5      M� 5      $ wm:FontType��6   5       S� 5"      $ 	GetValues��6?   "  6V    5#      M� 5$      $ wm:TextOrientation��6   5&      S� 5(      $ GetFontNames��64   "  6N   u�5*      3q�6/   �� 5,      "	 ��6   .�5-      �� 
 � ��$ Right=�6?   5.      �� 50      "	 ��6   .�51      �� 
 � ��8   6+   52      �� 54      "	 ��6   .�55      �� 
 � ��8   6+   56      �� 58      "	 ��6   .�59      �� 
 � ��8   6+   �� 5:      
 � ��$	 150��6*   5;      5<       � RowDefinitions 5>   
   �� 5?      $
��Auto �6   �� 5@      $
��Auto �6   �� 5A      $
��Auto �6   �� 5B      $
��Auto �6   �� 5C      $
��Auto �6   �� 5D      $
��Auto �6   �� 5E      $
��Auto �6   �� 5F      $
��Auto �6   �� 5G      $
��Auto �6   �� 5H      $
��Auto �6   �� 5I      $
��Auto �6    � ColumnDefinitions 5K   
   �� 5L      $
��Auto �6   �� 5M      .+�5P   
   �� $��0��6   $��0��6   .��6-   Supprimer l'original :6E   �� 5Q   
   $��0��6   $��1��6    $��Center=�60   {�.   d� 	IsChecked 6R   �� *
EraseFiles+6s   �� 5S   
   $��1��6   $��0��6   .��6-   Inclure les sous-dossiers :6J   �� 5T   
   $��1��6   $��1��6    $��Center=�60    6R   �� *IncludeSubFolders+�� 5V   
   $��2��6   $��0��6   .��6-   
Position :69   �� 5W   
   $��2��6   $��1��6    ��60   ��  �� Source# [  �� SelectedItem 6o   �� *Anchor+��5X      �� 5Y      .R�5Z      �� ��6    ��  �� 	Converter# [  5[      5]      �� 5_   
   $��3��6   $��0��6   .��6-   !Marge horizontale (en pixels) :6N   �� 5`   
   -   5        $��3��5`      $��1��6   ��6[   �� *	HMargin+�� 5b   
   $��4��6   $��0��6   .��6-   Marge verticale (en pixels) :6L   �� 5c   
   -   5        $��4��5c      $��1��6   ��6[   �� *	VMargin+�� 5e   
   $��5��6   $��0��6   .��6-   Police du texte :6@   �� 5f   
   $��5��6   $��1��6    ��60   �� # [  6k   �� *
FontName+��5g      �� 5h      .R�5i      �� ��6    �� 5j      5l      �� 5n   
   $��6��6   $��0��6   .��6-   Type de police :6?   �� 5o   
   $��6��6   $��1��6    ��60   �� # [  6o   �� *
FontType+��5p      �� 5q      .R�5r      �� ��6    �� # [ 5s      5u      �� 5w   
   $��7��6   $��0��6   .��6-   Orientation du texte :6E   �� 5x   
   $��7��6   $��1��6    ��60   �� # [  6v   �� *TextOrientation+��5y      �� 5z      .R�5{      �� ��6    �� # [ 5|      5~      �� 5�   
   $��8��6   $��0��6   .��6-   Taille du texte :6@   �� 5�   
   -   5        $��8��5�      $��1��6   ��6[   �� *
TextSize+�� 5�   
   $��9��6   $��0��6   .��6-   	Texte :66   �� 5�   
   $��9��6   $��1��6   ��6/   �� *Text+�� 5�   
   $��10��6   $��1��6   $
��Left=�6/   $��Center=�6J   $��Lancer le traitement��5�      ��60   �� *DrawWatermarks+5�      5�      
<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <!-- Преобразование элемента schedule -->
  <xsl:template match="schedule">
    <!-- Проход по всем дням в расписании -->
    <xsl:for-each select="day">
      <xsl:value-of select="@name"/>
      <xsl:text>&#xA;&#xA;</xsl:text>
      
      <!-- Проход по всем занятиям в текущем дне -->
      <xsl:for-each select="lesson">
        <xsl:value-of select="@subject"/>
        <xsl:text>, </xsl:text>
        <xsl:value-of select="@teacher"/>
        <xsl:text>, </xsl:text>
        <xsl:value-of select="@start"/>
        <xsl:text> - </xsl:text>
        <xsl:value-of select="@end"/>
        <xsl:text>&#xA;</xsl:text>
      </xsl:for-each>
      
      <xsl:text>&#xA;&#xA;</xsl:text>
    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>
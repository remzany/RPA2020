<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html"/>
    <xsl:template match="/">
	<html>
	
	<body>
	<xsl:for-each select="evi/student">
	<xsl:value-of select="ime"/>
	<xsl:value-of select="priimek"/>
	<xsl:value-of select="smer"/>
	<xsl:value-of select="index"/>
	<xsl:value-of select="letnik"/>
	<xsl:for-each select="evi/student/izpit">
	<xsl:value-of select="predmet"/>
	<xsl:value-of select="datum"/>
	<xsl:value-of select="ocena"/>
	</xsl:for-each>
	<br/>
	</body>
    </html>
    </xsl:template>
</xsl:stylesheet>
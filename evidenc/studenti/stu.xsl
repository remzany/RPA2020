<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html"/>
    <xsl:template match="/">
	<html>
	<head><title>Danijel v</title></head>
		<body>
			<table border="1" style="border: 2px solid black;">
			<tr>
				<td>ImePRiimek</td>
				<td>Letnik</td>
				<td>Smer</td>
				<td>Predmet</td>
				<td>Ocena</td>			
			</tr>
				<xsl:for-each select="redovalnica/student/ocena">
				<xsl:sort select="../imePriimek"/>
				<tr>
				
					<td><xsl:value-of select="../imePriimek"/></td>
					<td><xsl:value-of select="../letnik"/></td>
					<td><xsl:value-of select="../smer"/></td>
					<td><xsl:value-of select="predmet"/></td>
					<td><xsl:value-of select="ocena1"/></td>
				</tr>
				</xsl:for-each>	
				
			
			</table>
	
		</body>
	</html>
</xsl:template>
</xsl:stylesheet>
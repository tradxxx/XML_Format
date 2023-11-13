<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/">
		<html>
			<head>
				<style>
					table {
					border-collapse: collapse;
					width: 100%;
					}

					th, td {
					border: 1px solid #dddddd;
					text-align: left;
					padding: 8px;
					}

					th {
					background-color: #f2f2f2;
					}
				</style>
			</head>
			<body>
				<h2>Расписание</h2>
				<table>
					<tr>
						<th>День</th>
						<th>Предмет</th>
						<th>Преподаватель</th>
						<th>Аудитория</th>
						<th>Начало</th>
						<th>Конец</th>
						<th>Тип</th>
					</tr>
					<xsl:apply-templates select="//lesson"/>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="lesson">
		<tr>
			<td>
				<xsl:value-of select="../@name"/>
			</td>
			<td>
				<xsl:value-of select="@subject"/>
			</td>
			<td>
				<xsl:value-of select="@teacher"/>
			</td>
			<td>
				<xsl:value-of select="@room"/>
			</td>
			<td>
				<xsl:value-of select="@start"/>
			</td>
			<td>
				<xsl:value-of select="@end"/>
			</td>
			<td>
				<xsl:value-of select="@type"/>
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>

<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/">
		<html>
			<head>
				<style>
					h2 { text-align: center }

					table {
					border-collapse: collapse;
					width: 100%;
					margin: 15px 0;
					box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
					font-family: 'Arial', sans-serif;
					}

					th, td {
					border: 1px solid #ddd;
					padding: 12px;
					text-align: left;
					}

					th {
					background-color: #f2f2f2;
					font-weight: bold;
					}

					tr:nth-child(even) {
					background-color: #f9f9f9;
					}

					tr:nth-child(odd) {
					background-color: #e6e6e6;
					}

					tr:hover {
					background-color: #d9edf7;
					transition: background-color 0.3s;
					}
				</style>

			</head>
			<body>
				<h2 >Расписание</h2>
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
					<xsl:apply-templates select="//tutorial"/>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="tutorial">
		<tr>
			<td>
				<xsl:value-of select="../name"/>
			</td>
			<td>
				<xsl:value-of select="subject"/>
			</td>
			<td>
				<xsl:value-of select="teacher"/>
			</td>
			<td>
				<xsl:value-of select="room"/>
			</td>
			<td>
				<xsl:value-of select="start"/>
			</td>
			<td>
				<xsl:value-of select="end"/>
			</td>
			<td>
				<xsl:value-of select="type"/>
			</td>
		</tr>
	</xsl:template>

</xsl:stylesheet>

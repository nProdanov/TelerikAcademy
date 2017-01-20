<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <style>
        body {
        background-color: pink;
        }

        ul {
        list-style: none;
        }
      </style>

      <body>
        <ul>
          <xsl:for-each select="students/student" >
            <li>
              Name:
              <strong>
                <xsl:value-of select="name"/>
              </strong>
            </li>
            <li>
              Gender:
              <strong>
                <xsl:value-of select="sex"/>
              </strong>
            </li>
            <li>
              Date of birth:  <strong>
                <xsl:value-of select="birthdate"/>
              </strong>
            </li>
            <li>
              Phone number:  <strong>
                <xsl:value-of select="phone"/>
              </strong>
            </li>
            <li>
              Course: <strong>
                <xsl:value-of select="course"/>
              </strong>
            </li>
            <li>
              Specialty: <strong>
                <xsl:value-of select="specialty"/>
              </strong>
            </li>
            <li>
              Exams:
              <strong>
                <ul>
                  <xsl:for-each select="exams/exam" >
                    <li>
                      Course name: <xsl:value-of select="@name" />
                    </li>
                    <li>
                      Tutor name: <xsl:value-of select="tutor" />
                    </li>
                    <li>
                      Exam score: <xsl:value-of select="score" />
                    </li>
                  </xsl:for-each>
                </ul>
              </strong>
            </li>
            <li>
              Enrollment:
              <strong>
                <ul>
                  <xsl:for-each select="enrollment" >
                    <li>
                      Date of enrollment: <xsl:value-of select="date"/>
                    </li>
                    <li>
                      Score of tests: <xsl:value-of select="score"/>
                    </li>
                  </xsl:for-each>
                </ul>
              </strong>
            </li>

          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>

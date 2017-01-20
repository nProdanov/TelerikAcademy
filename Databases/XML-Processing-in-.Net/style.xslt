<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <style>
        body {
        background-colour: pink;
        }

        ul{
        list-style: none;
        }
        
        .album{
          border: 1px solid black;
          width: 30%;
        }
      </style>

      <body>
        <ul class="albums-list">
          <xsl:for-each select="catalogue/album">
            <li>
              <ul class="album">
                <li>
                  Name:
                  <strong>
                    <xsl:value-of select="name" />
                  </strong>
                </li>
                <li>
                  Artist:
                  <strong>
                    <xsl:value-of select="artist" />
                  </strong>
                </li>
                <li>
                  Year:
                  <strong>
                    <xsl:value-of select="year" />
                  </strong>
                </li>
                <li>
                  Producer:
                  <strong>
                    <xsl:value-of select="producer" />
                  </strong>
                </li>
                <li>
                  Price:
                  <strong>
                    <xsl:value-of select="price" />
                  </strong>
                </li>
                <li>
                  Songs:
                  <ul>
                    <xsl:for-each select="songs/song">
                      <li>
                        <strong>
                          <xsl:value-of select="title"/>
                          -
                          <xsl:value-of select="duration"/>
                        </strong>

                      </li>
                    </xsl:for-each>
                  </ul>
                </li>
              </ul>
            </li>
            <br/>
          </xsl:for-each>
        </ul>
      </body>
    </html>

  </xsl:template>
</xsl:stylesheet>

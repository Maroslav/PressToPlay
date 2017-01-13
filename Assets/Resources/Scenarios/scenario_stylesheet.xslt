<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:p="http://presstoplaygame.com/scenario">
    <xsl:output method="html" indent="yes"/>

  <xsl:template match="/p:Scenario">
    <html>
      <head>
        <style type="text/css">
          <![CDATA[
          body {
            font-size: 14px;
            font-family: verdana;
            background-color: white;
          }
          div.event {
            padding: 10px;
            margin: 10px;
            background-color: #F5DA81;
          }
          div.content {
             margin:auto;
             width: 600px;
          }
          p.preconditionclass{
            color: grey;
            margin:10px 0;
          }
          h2 {
            text-align: center;
          }
          img{
             /*width:100%;*/
             max-width:500px;
             margin: 20px;
            }
        ]]>
        </style>

      </head>
      <body>
        <div class="content">
        <h2>
          Scenario:  <xsl:value-of select="@name" />
        </h2>
          <xsl:apply-templates/>
        </div>
      </body>
    </html>
  </xsl:template>
  <xsl:template match="p:MultipleChoiceEvent">
    <div class="event">
    <h3>MultipleChoiceEvent: <xsl:value-of select="@name"/></h3>
      <p class ="preconditionclass">
        
    <xsl:apply-templates select="p:Preconditions"/> <!--preconditions-->
      </p>
       <xsl:if test="@isTerminating='true'">
        <br/>
        <b><xsl:text>[TERMINATING]</xsl:text></b>
       <br/>
      </xsl:if>
   <b>Description: </b>
    <xsl:value-of select="p:Description"/>
      <xsl:if test="@date">
        <br/>
        <b>Date: </b>
        <xsl:value-of select="@date"/>
      </xsl:if>
    <xsl:apply-templates select="p:Choices"/>
    </div>
  </xsl:template>
  
  <xsl:template match="p:CutsceneEvent">
    <div class="event">
      <h3>Cutscene Event</h3>
      <p class="preconditionclass">
        <xsl:apply-templates select="p:Preconditions"/>
      </p>
      <xsl:if test="@isTerminating='true'">
        <br/>
        <b><xsl:text>[TERMINATING]</xsl:text></b>
      <br/>
      </xsl:if>
      <b>Text: </b>
      <xsl:value-of select="p:Text"/>
      <xsl:if test="@date">
        <br/>
        <b>Date: </b>
        <xsl:value-of select="@date"/>
      </xsl:if>
      <img src="../Images/Cutscenes/{p:ImagePath}.jpg" alt="../Images/Cutscenes/{p:ImagePath}.jpg"></img>
    </div>
  </xsl:template>
  
  <xsl:template match="p:ImageChoiceEvent">
    <div class="event">
      <h3>Image Choice Event</h3>
      <xsl:apply-templates select="p:Preconditions"/>
    
       <xsl:apply-templates select="p:Preconditions"/> <!--preconditions-->
       <xsl:if test="@isTerminating='true'">
        <br/>
        <b><xsl:text>[TERMINATING]</xsl:text></b>
       <br/>
      </xsl:if>
        <xsl:for-each select="p:Choices/p:Choice">
      <ul>
        <li>
          <xsl:value-of select="p:ImagePath"/>
         <img src="../ImageChoiceEvents/{p:ImagePath}.jpg" alt="../ImageChoiceEvents/{p:ImagePath}.jpg"></img>
          
      </li>
      </ul>
    </xsl:for-each>
    </div>
  </xsl:template>

  <xsl:template match="p:Preconditions">
    <i>
    <xsl:for-each select="p:Precondition">
      
      <xsl:value-of select="@attribute"/>
      <xsl:if test="@operation='greater'">
        <xsl:text>&gt;</xsl:text>
      </xsl:if>
      <xsl:if test="@operation='less'">
        <xsl:text>&lt;</xsl:text>
      </xsl:if>
      <xsl:if test="@operation='lessOrEqual'">
        <xsl:text>&lt;=</xsl:text>
      </xsl:if>
      <xsl:if test="@operation='equal'">
        <xsl:text>=</xsl:text>
      </xsl:if>
      <xsl:value-of select="@value"/>
      <xsl:choose>
        <xsl:when test="position() != last()">
          <xsl:text>, </xsl:text>
        </xsl:when>
        <xsl:otherwise>
          <br/>
        </xsl:otherwise>
      </xsl:choose>
     
    </xsl:for-each>
     </i>
  </xsl:template>

  <xsl:template match="p:Choices">
    <xsl:for-each select="p:Choice">
      <ul>
        <li>
          <i>
          <xsl:value-of select="p:ChoiceText"/>
          </i>
          <br/>
          <xsl:value-of select="p:Title"/>
          <br/>
          <xsl:value-of select="p:Description"/>
          <xsl:apply-templates select="p:Effects"/>
      </li>
      </ul>
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="p:Effects">
    <div>
      <xsl:for-each select="*">

        <xsl:if test="position()=1">
          <xsl:text>Effects: </xsl:text>
        </xsl:if>
        <xsl:apply-templates select="."/>
       <xsl:if test="position()!=last()">
          <xsl:text>, </xsl:text>
        </xsl:if>
      </xsl:for-each>
    </div>
  </xsl:template>
  <xsl:template match="p:SetEffect">
    <xsl:value-of select="@attribute"/>
    <xsl:text> = </xsl:text>
    <xsl:value-of select="@value"/>
  </xsl:template>

  <xsl:template match="p:ModifyEffect">
    <xsl:value-of select="@attribute"/>
    <xsl:choose>
    <xsl:when test="@value &gt; 0">
      <xsl:text> + </xsl:text>
      <xsl:value-of select="@value"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:text> - </xsl:text>
        <xsl:value-of select="-1*@value"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <xsl:template match="p:MoveTowardsEffect">
    <xsl:value-of select="@attribute"/>
    <xsl:text> moves towards </xsl:text>
    <xsl:value-of select="@value"/>
    <xsl:if test="@amount">
      <xsl:text> by </xsl:text>
      <xsl:value-of select="@amount"/>
    </xsl:if>
  </xsl:template>

    <!--Replace default behaviour: copying of all text elements-->
  <xsl:template match="text()|@*">
  </xsl:template>
</xsl:stylesheet>

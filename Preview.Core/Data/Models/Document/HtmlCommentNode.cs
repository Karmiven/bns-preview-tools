﻿// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

namespace Xylia.Preview.Data.Models.Document;
/// <summary>
/// Represents an HTML comment.
/// </summary>
public class HtmlCommentNode : HtmlNode
{
    #region Fields

    private string _comment;

    #endregion

    #region Constructors

    internal HtmlCommentNode(HtmlDocument ownerdocument, int index)
        :
        base(HtmlNodeType.Comment, ownerdocument, index)
    {
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or Sets the comment text of the node.
    /// </summary>
    public string Comment
    {
        get
        {
            if (_comment == null)
            {
                return base.InnerHtml;
            }

            return _comment;
        }
        set { _comment = value; }
    }

    /// <summary>
    /// Gets or Sets the HTML between the start and end tags of the object. In the case of a text node, it is equals to OuterHtml.
    /// </summary>
    public override string InnerHtml
    {
        get
        {
            if (_comment == null)
            {
                return base.InnerHtml;
            }

            return _comment;
        }
        set { _comment = value; }
    }

    /// <summary>
    /// Gets or Sets the object and its content in HTML.
    /// </summary>
    public override string OuterHtml
    {
        get
        {
            if (_comment == null)
            {
                return base.OuterHtml;
            }

            if (_comment.StartsWith("<!--") && _comment.EndsWith("-->"))
            {
                return _comment;
            }

            return "<!--" + _comment + "-->";
        }
    }

    #endregion
}
﻿// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright © ZZZ Projects Inc. All rights reserved.

namespace Xylia.Preview.Data.Models.Document;
/// <summary>
/// Represents the type of parsing error.
/// </summary>
public enum HtmlParseErrorCode
{
    /// <summary>
    /// A tag was not closed.
    /// </summary>
    TagNotClosed,

    /// <summary>
    /// A tag was not opened.
    /// </summary>
    TagNotOpened,

    /// <summary>
    /// There is a charset mismatch between stream and declared (META) encoding.
    /// </summary>
    CharsetMismatch,

    /// <summary>
    /// An end tag was not required.
    /// </summary>
    EndTagNotRequired,

    /// <summary>
    /// An end tag is invalid at this position.
    /// </summary>
    EndTagInvalidHere
}
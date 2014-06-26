// -------------- Task 1 -------------------
String.prototype.reverse = function () {
    var gnirts = '';
    for (var char = this.length - 1; char >= 0; char--) {
        gnirts += this[char];
    }

    return gnirts;
}

function Task1() {
    console.log('Task 1 - Reverse string: ');
    var string = 'аз обичам мач и боза';
    console.log(string);
    console.log();
    console.log('Reversed:');
    console.log(string.reverse());
}

Task1();

// -------------- Task 2 -------------------
function areBracketsOK(expressionString) {
    var nestedCounter = 0;
    for (var char in expressionString) {
        if (expressionString[char] == ')') {
            nestedCounter--;
        }
        if (expressionString[char] == '(') {
            nestedCounter++;
        }
        if (nestedCounter < 0) { // closing before opening (-1)
            return false;
        }
    }
    
    if (nestedCounter == 0) {
        return true;
    } else {
        return false;
    }
}

function Task2() {
    var expressionString1 = ")(a+b))",
        expressionString2 = "((a+b)/5-d)";
        
    console.log();
    console.log('Task 2 - Check brackets');
    console.log('Expression ' + expressionString1 + ' OK?');
    console.log(areBracketsOK(expressionString1));

    console.log();
    console.log('Expression ' + expressionString2 + ' OK?');
    console.log(areBracketsOK(expressionString2));
}

Task2();

// -------------- Task 3 -------------------

function substringCount(word, text) {
    var wordCount = 0,
       splittedText = text.split(word);
    return splittedText.length;
}

function Task3() {
    var word = 'in',
        text = 'We are living in an yellow submarine. We don\'t have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.';

    console.log();
    console.log('Task 3 - Substring count: ');
    console.log('The text is');
    console.log(text);

    console.log();
    console.log('The word "' + word + '" can be found ' + substringCount(word, text) + ' times');
}

Task3();

// -------------- Task 4 -------------------

function changeText(taggedText) {
    var textCase = {
        CLEAN : 0,
        UPCASE : 1,
        LOWCASE : 2,
        MIXCASE : 3
    };

    var nestedCasesArray = [],
        currentCase = textCase.CLEAN;

    var isInTag = false,
        isClosingTag = false,
        currentCaseTag = '',
        resultText = '';

    nestedCasesArray.unshift(currentCase); // resetting case to CLEAN

    function applyCase(tCase, char) {
        switch (tCase) {
            case textCase.CLEAN: return char; break;
            case textCase.UPCASE: return char.toUpperCase(); break;
            case textCase.LOWCASE: return char.toLowerCase(); break;
            case textCase.MIXCASE:
                {
                    if (Math.random() >= 0.5) {
                        return char.toUpperCase();
                    } else {
                        return char.toLowerCase();
                    }
                    break;
                }
            default:
        }
    }

    function getCase(string) {
        switch (string) {
            case 'clean': return textCase.CLEAN; break;
            case 'upcase': return textCase.UPCASE; break;
            case 'lowcase': return textCase.LOWCASE; break;
            case 'mixcase': return textCase.MIXCASE; break;
            default:
                return textCase.CLEAN;
        }
    }

    for (var char = 0; char < taggedText.length; char++) {
        switch (taggedText[char]) {
            case '<':
                isInTag = true; break;
            case '>':
                if (isInTag) {
                    isInTag = false;
                    if (isClosingTag) { // an end of a closing tag (</tag>)
                        if (nestedCasesArray.length > 0) {
                            currentCase = nestedCasesArray.shift(); // remove current formatting
                            currentCase = nestedCasesArray[0];
                        } else {
                            currentCase = getCase('clean');
                        }
                        isClosingTag = false;
                    } else {            // an end of an opening tag (<tag>)
                        currentCase = getCase(currentCaseTag); // set formatting
                        nestedCasesArray.unshift(currentCase); // add case to array
                    }
                    currentCaseTag = '';
                };
               // console.log(nestedCasesArray);
               // console.log(' ' + currentCase);
                break;

            case '/':
                if (isInTag) {
                    isClosingTag = true;
                }
                break;

            default:
                if (isInTag) {
                    currentCaseTag += taggedText[char];
                } else {
                    resultText += applyCase(currentCase, taggedText[char]); // applies formatting
                }
        }
    }
    return resultText;
}

function Task4() {
    var example = 'We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don\'t</mixcase> have <lowcase>anything</lowcase> else.',
        nestedExample = 'Normal, <upcase> upcase here, <mixcase>some mixcase in upcase,</mixcase> backto upcase, <mixcase>and again mixcase in upcase,</mixcase> and fallback of upcase.</upcase> Plain here, <mixcase>mixcase text,</mixcase> plain again <lowcase>and LOWERCASE </lowcase>';

    console.log();
    console.log('Task 4 - Markup language transform');

    console.log();
    console.log('Default Example:');
    console.log(example);
    console.log();
    console.log(changeText(example));

    console.log();
    console.log();
    console.log('Nested Example:');
    console.log(nestedExample);
    console.log();
    console.log(changeText(nestedExample));

}

Task4();

// -------------- Task 5 -------------------
function whiteSpacesToNbsp(text) {
    var res = '';
    for (var char = 0; char < text.length; char++) {
        if (text[char] == ' ') {
            res += '&nbsp;';
        } else {
            res += text[char];
        }
    }
    return res;
}

function Task5(){
    var text = 'Write a function that replaces non breaking white-spaces in a text with &nbsp;';

    console.log();
    console.log('Task 5 - Whitespaces');
    console.log(text);
    text = whiteSpacesToNbsp(text);
    console.log(text);
}

Task5();

// -------------- Task 6 -------------------
function extractHTMLContent(htmlString) {
    var htmlContent = '',
        isInTag = false,
        isClosingTag = false;

    for (var char = 0; char < htmlString.length; char++) {
        switch (htmlString[char]) {
            case '<':
                isInTag = true; break;
            case '>':
                if (isInTag) {
                    isInTag = false;
                    isClosingTag = true;
                };
                break;
            default:
                if (isInTag) {
                    break;
                } else {
                    if (isClosingTag) {
                        htmlContent += ' ';
                        isClosingTag = false;
                    }
                    htmlContent += htmlString[char];
                    break;
                }
        }
    }

    return htmlContent;
}

function Task6() {
    var testHtml = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';

    console.log();
    console.log('Task 6 - Extract the content of a html page:');
    console.log();
    console.log('Input :');
    console.log(testHtml);
    console.log();
    console.log('Output :');
    console.log(extractHTMLContent(testHtml));
}

Task6();

// -------------- Task 7 -------------------

function urlToJSON(url) {
    var urlPart = {
        PROTOCOL: 0,
        SERVER: 1,
        RESOURCE: 2,
        PORT: 3
    };

    var scope = urlPart.PROTOCOL,
        protocol = '',
        server = '',
        resource = '',
        port = '',
        separator = '';

    for (var char = 0; char < url.length; char++) {
        if (scope == urlPart.PROTOCOL) {
            if (url[char] != ':'
                && url[char] != '/' ) {
                protocol += url[char];
            } else {
                separator += url[char];
            }
            if (separator == '://') {
                scope = urlPart.SERVER;
                separator = '';
                continue;
            }
        }

        if (scope == urlPart.SERVER) {
            if (url[char] != '/') {
                server += url[char];
            } else {
                separator += url[char];
            }
            if (separator == '/') {
                scope = urlPart.RESOURCE
                separator = '';
                continue;
            }
        }

        if (scope == urlPart.RESOURCE) {
            if (url[char] != ':') {
                resource += url[char];
            } else {
                separator += url[char];
            }
            if (separator == ':') {
                scope = urlPart.PORT;
                separator = '';
                continue;
            }
        }

        if (scope == urlPart.PORT) {
            port += url[char];
        }
    }

    var jsonUrl = {
        protocol: protocol,
        server: server,
        resource: resource,
        port: port
    }

    return jsonUrl;
}

function Task7() {
    var url = 'http://www.devbg.org/forum/index.php:80';

    console.log();
    console.log('Task 7 - URL to JSON :');
    console.log('URL : ');
    console.log(url);
    console.log();
    console.log('JSON :');
    console.log(urlToJSON(url));
}

Task7();

function replaceHrefTag(htmlInput) {
    var outputML = htmlInput;

    for (var i = 0; i < htmlInput.split('<a href="', 90).length - 1; i++) {
        outputML = outputML.replace('<a href="', '[URL=');
        outputML = outputML.replace('">', ']');
        outputML = outputML.replace('</a>', '[/URL]');
    }
    return outputML;
}

function Task8() {
    var sample = '<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

    console.log();
    console.log('Task 8');
    console.log(sample);
    console.log();
    console.log(replaceHrefTag(sample));

}

Task8();
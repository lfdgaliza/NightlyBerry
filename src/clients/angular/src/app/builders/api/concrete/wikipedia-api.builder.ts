import { environment } from 'src/environments/environment';

import { BaseApiGetUrlBuilder } from '../base-api-get-url.builder';

export class WikipediaApiBuilder extends BaseApiGetUrlBuilder
{
    public lang: string

    public withTitle(title: string): WikipediaApiBuilder
    {
        this.parameters.push({ key: "format", value: "json" })
        this.parameters.push({ key: "action", value: "query" })
        this.parameters.push({ key: "prop", value: "extracts" })
        this.parameters.push({ key: "exintro", value: "true" })
        this.parameters.push({ key: "explaintext", value: "true" })
        this.parameters.push({ key: "redirects", value: "1" })
        this.parameters.push({ key: "origin", value: "*" })

        this.parameters.push({ key: "titles", value: title })

        return this
    }

    public withLang(lang: string): WikipediaApiBuilder
    {
        this.lang = lang
        return this
    }

    public buildBaseUrl(): string
    {
        return environment.api.wikipedia.baseUrl.replace('<lang>', this.lang)
    }
}
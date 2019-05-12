import { Parameter } from 'src/app/models/api/parameter.model';

export abstract class BaseApiGetUrlBuilder
{
    parameters: Parameter[] = new Array<Parameter>()

    public withParameters(parameters: Parameter[]): BaseApiGetUrlBuilder
    {
        this.parameters = parameters
        return this
    }

    protected abstract buildBaseUrl(): string

    public buildParameters(): string
    {
        return this.parameters.length > 0
            ? '?' + this.parameters.map(m => `${m.key}=${m.value}`).join('&')
            : ''
    }

    public buildUrl(): string
    {
        return this.buildBaseUrl() + this.buildParameters()
    }

    public buildUrlEncoded(): string
    {
        return encodeURI(this.buildUrl())
    }
}
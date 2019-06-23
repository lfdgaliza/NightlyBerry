import { environment } from 'src/environments/environment';

import { BaseApiGetUrlBuilder } from '../base-api-get-url.builder';

export class DistroGuideApiBuilder extends BaseApiGetUrlBuilder
{
    private partition: string
    private path: string

    public withPartition(partition: string): DistroGuideApiBuilder
    {
        this.partition = partition
        return this
    }

    public withPath(path: string): DistroGuideApiBuilder
    {
        this.path = path
        return this
    }

    public buildBaseUrl(): string
    {
        return `${
            environment.api.dg.host}/${
            this.partition || environment.api.dg.partition}/${
            this.path}`
    }
}
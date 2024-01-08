/** @type {import('next').NextConfig} */
const nextConfig = {
    experimental: {
        logging: "verbose"
      },
      images:{
        domains:[
          'cdn.pixabay.com'
        ]
      }
}

module.exports = nextConfig

uniform vec3 Spacing;
uniform vec3 Size;

uniform float angleStep1;
uniform float angleStep2;

uniform int thresholdUp;
uniform int thresholdDown;
uniform float gradient;

uniform float xy_start;
uniform float xz_start;

uniform float startX;
uniform float startY;
uniform float startZ;

uniform sampler3D tex;

varying out vec4 color; //delete "varying" in order to run on intel



void main(void)
{
//   color = vec4(gl_FragCoord[0] - 0.5, 
//       gl_FragCoord[1] - 0.5, 
//       texture(tex, vec3((gl_FragCoord[0] - 0.5) / 10, (gl_FragCoord[1] - 0.5) / 10, Size[2] / 2.0)).r, 
//       12.3);

    float angle1 = xy_start + (gl_FragCoord[0] - 0.5) * angleStep1;
    float angle2 = xz_start + (gl_FragCoord[1] - 0.5) * angleStep2;

    float X = startX / Size[0];
    float Y = startY / Size[1];
    float Z = startZ / Size[2];

    float x1 = cos(angle1) * sin(angle2);
    float y1 = sin(angle1) * sin(angle2);
    float z1 = cos(angle2) * Spacing[0] / Spacing[2];

    float ax = abs(x1);
    float ay = abs(y1);
    float az = abs(z1);
    float maxSize = max(Size[0], max(Size[1], Size[2]));
    float coef = 2;

    if (ax > ay && ax > az)
    {
        x1 = x1/(coef*ax*maxSize); y1 = y1/(coef*ax*maxSize); z1 = z1/(coef*ax*maxSize);
    }
    else if (ay > ax && ay > az)
    {
        x1 = x1/(coef*ay*maxSize); y1 = y1/(coef*ay*maxSize); z1 = z1/(coef*ay*maxSize);
    }
    else
    {
        x1 = x1/(coef*az*maxSize); y1 = y1/(coef*az*maxSize); z1 = z1/(coef*az*maxSize);
    }

    float x = X, y = Y, z = Z;
    float value = texture(tex, vec3(x, y, z)).r;

//    color = vec4(gl_FragCoord[0] - 0.5, gl_FragCoord[1] - 0.5, value, 0);
//    return;

    while ((x < 1 && x > 0) && (y < 1 && y > 0) && (z < 1 && z > 0))
    {
        value = texture(tex, vec3(x + x1, y+y1, z+z1));
        
        if (value < thresholdDown || value > thresholdUp) 
        {
            x = x * Size[0]; 
            y = y * Size[1]; 
            z = z * Size[2];
            float dist = sqrt((x - startX) * (x - startX) 
                            + (y - startY) * (y - startY) 
                            + (z - startZ) * (z - startZ));
            color = vec4(x, y, z, dist);
            
            return;
        }

        x = x + x1; y = y+y1; z = z+z1;
    }

    x = (x - x1) * Size[0]; 
    y = (y - y1) * Size[1]; 
    z = (z - z1) * Size[2];
    float dist = sqrt((x - startX) * (x - startX) 
                    + (y - startY) * (y - startY) 
                    + (z - startZ) * (z - startZ));
    color = vec4(x, y, z, dist);
}